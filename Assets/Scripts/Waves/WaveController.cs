using UnityEngine;
using System;
using System.Collections.Generic;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<Wave> waves = new List<Wave>();

    private int currentWaveIndex;

    public int CurrentWaveIndex
    {
        get { return currentWaveIndex; }
    }

    public event Action WaveChanged;
    public event Action WavesCompleted;

    public void StartWaves()
    {
        if (waves.Count > 0)
        {
            InitialiseCurrentWave();
        }
        else
        {
            print("No waves on Wave Controller");
            SafelyEmitEvent(ref WavesCompleted);
        }
    }

    public void SafelyEmitEvent(ref Action eventAction)
    {
        if (eventAction != null)
        {
            eventAction.Invoke();
        }
    }

    private void InitialiseCurrentWave()
    {
        if (currentWaveIndex >= waves.Count)
        {
            SafelyEmitEvent(ref WavesCompleted);
        }
        
        var wave = waves[currentWaveIndex];
        wave.WaveCompleted += NextWave;
        wave.BeginWave();
        SafelyEmitEvent(ref WaveChanged);
    }

    private void NextWave(object sender, EventArgTemplate<bool> success)
    {
        if (success.Attachment)
        {
            waves[currentWaveIndex].WaveCompleted -= NextWave;
            currentWaveIndex++;

            if (currentWaveIndex >= waves.Count)
            {
                SafelyEmitEvent(ref WavesCompleted);
            }
            else
            {
                InitialiseCurrentWave();
            }
        }
    }
}