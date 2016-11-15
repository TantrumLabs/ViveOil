using UnityEngine;
using System.Collections;

public class ViveHand : MonoBehaviour
{
    [SerializeField] bool hapticOnStay;

    [SerializeField]
    GameObject selectedObject = null;
    GameObject viveControllerModel;
    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObject;
    SteamVR_TrackedController trackedHand;
    bool trigger = false;

    void Start ()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        trackedHand = GetComponent<SteamVR_TrackedController>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }
	
    void Update()
    {
        if (selectedObject == null)
            return;

        if (trackedHand.triggerPressed && !trigger && selectedObject != null)
        {
            trigger = true;
            selectedObject.GetComponent<IInteractableObject>().Interact();
        }
        else if (!trackedHand.triggerPressed && trigger)
        {
            trigger = false;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.GetComponent<IInteractableObject>() != null)
        {
            if (selectedObject != null)
            {
                selectedObject.GetComponent<IInteractableObject>().Touch(false);
            }

            selectedObject = c.gameObject;
            selectedObject.GetComponent<IInteractableObject>().Touch(true);
            HapticPulse();
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.GetComponent<IInteractableObject>() != null)
        {
            selectedObject.GetComponent<IInteractableObject>().Touch(false);
            selectedObject = null;
            HapticPulse();
        }
    }

    void HapticPulse()
    {
        //device = SteamVR_Controller.Input((int)trackedObject.index);
        device.TriggerHapticPulse(500); // 
    }

}
