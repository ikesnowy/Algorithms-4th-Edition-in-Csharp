namespace _3._1._4;

public class Event
{
    public string EventMessage { get; set; }

    public Event() : this(null) { }

    public Event(string message)
    {
        EventMessage = message;
    }

    public override string ToString()
    {
        return EventMessage;
    }
}