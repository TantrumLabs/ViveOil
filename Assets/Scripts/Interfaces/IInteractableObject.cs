public interface IInteractableObject
{
    bool inUse { get; set; }

    void PickUp();
    void PutDown();


}
