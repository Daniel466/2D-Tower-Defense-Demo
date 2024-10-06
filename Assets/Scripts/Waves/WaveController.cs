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
            SafeEventHandler.SafelyBroadcastAction(ref WavesCompleted);
        }
    }

    private void InitialiseCurrentWave()
    {
        if (currentWaveIndex >= waves.Count)
        {
            SafeEventHandler.SafelyBroadcastAction(ref WavesCompleted);
        }
        
        var wave = waves[currentWaveIndex];
        wave.WaveCompleted += NextWave;
        wave.BeginWave();
        SafeEventHandler.SafelyBroadcastAction(ref WaveChanged);
    }

    private void NextWave(object sender, EventArgTemplate<bool> success)
    {
        if (success.Attachment)
        {
            waves[currentWaveIndex].WaveCompleted -= NextWave;
            currentWaveIndex++;

            if (currentWaveIndex >= waves.Count)
            {
                SafeEventHandler.SafelyBroadcastAction(ref WavesCompleted);
            }
            else
            {
                InitialiseCurrentWave();
            }
        }
    }
}