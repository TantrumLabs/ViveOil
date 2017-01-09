public interface IEvent
{
    bool isComplete { get; set; }
    UnityEngine.GameObject self { get; }
}