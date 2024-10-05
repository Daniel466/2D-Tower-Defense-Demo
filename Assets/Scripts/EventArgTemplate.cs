using System;

public class EventArgTemplate<T> : EventArgs
{
    public T Attachment { get; private set; }

    public EventArgTemplate(T attachment)
    {
        Attachment = attachment;
    }
}