using UnityEngine;
using System.Collections;

public class ExtinguisherDisposal : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {

        IInteractableObject i = other.GetComponent<IInteractableObject>();
        if (i != null)
        {
            i.Interact();
        }
    }
}
