using System;

public abstract class Wave : PausableTimer
{
    protected int currentInstructionIndex;

    public event EventHandler<EventArgTemplate<bool>> WaveCompleted;

    public virtual void BeginWave()
    {
        CompleteNextInstruction();
    }

    public virtual void HandleCompletion(bool success)
    {
        if (WaveCompleted != null)
        {
            var completion = new EventArgTemplate<bool>(success);
            WaveCompleted.Invoke(this, completion);
        }
    }

    protected abstract void CompleteNextInstruction();
}