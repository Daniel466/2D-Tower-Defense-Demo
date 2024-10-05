using UnityEngine;

public class PausableTimer : MonoBehaviour
{
    public float Timer { get; private set; }
    
    protected void Start()
    {
       ResetTimer();
    }

    protected void Update()
    {
        Timer += Time.deltaTime;
    }

    protected void ResetTimer()
    {
        Timer = 0.0f;
    }
}