using UnityEngine;
using System.Collections;

public class ViveHand : MonoBehaviour
{
    //[SerializeField] bool hapticOnStay;

    //[SerializeField]
    //GameObject selectedObject = null;
    //GameObject viveControllerModel;
    //SteamVR_Controller.Device device;
    //SteamVR_TrackedObject trackedObject;
    //SteamVR_TrackedController trackedHand;
    //bool trigger = false;

    //void Start ()
    //{
    //    trackedObject = GetComponent<SteamVR_TrackedObject>();
    //    trackedHand = GetComponent<SteamVR_TrackedController>();
    //    device = SteamVR_Controller.Input((int)trackedObject.index);
    //}

    //void Update()
    //{
    //    if (selectedObject == null)
    //        return;

    //    if (trackedHand.triggerPressed && !trigger && selectedObject != null)
    //    {
    //        trigger = true;
    //        selectedObject.GetComponent<IInteractableObject>().Interact();
    //    }
    //    else if (!trackedHand.triggerPressed && trigger)
    //    {
    //        trigger = false;
    //    }
    //}

    //void OnTriggerEnter(Collider c)
    //{
    //    if (c.gameObject.GetComponent<IInteractableObject>() != null)
    //    {
    //        if (selectedObject != null)
    //        {
    //            selectedObject.GetComponent<IInteractableObject>().Touch(false);
    //        }

    //        selectedObject = c.gameObject;
    //        selectedObject.GetComponent<IInteractableObject>().Touch(true);
    //        HapticPulse();
    //    }
    //}

    //void OnTriggerExit(Collider c)
    //{
    //    if (c.gameObject.GetComponent<IInteractableObject>() != null)
    //    {
    //        selectedObject.GetComponent<IInteractableObject>().Touch(false);
    //        selectedObject = null;
    //        HapticPulse();
    //    }
    //}

    //void HapticPulse()
    //{
    //    //device = SteamVR_Controller.Input((int)trackedObject.index);
    //    device.TriggerHapticPulse(500); // 
    //}

    /// /////////////////////////////////////////////////////////////////////////
    //[SerializeField] bool hapticOnStay;
    [SerializeField] GameObject m_SelectedObject = null;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObject;
    SteamVR_TrackedController trackedHand;

    GameObject viveControllerModel;
    bool trigger = false;
    
    private GameObject m_ObjectInHand;

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        trackedHand = GetComponent<SteamVR_TrackedController>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    void Update()
    {
        if (m_SelectedObject == null)
            return;

        else if (trackedHand.triggerPressed && !trigger)
        {
            trigger = true;
            m_SelectedObject.GetComponent<IInteractableObject>().Interact();
        }
        else if (!trackedHand.triggerPressed && trigger)
        {
            trigger = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IInteractableObject>() != null)
        {
            if (m_SelectedObject != null)
            {
                m_SelectedObject.GetComponent<IInteractableObject>().Touch(false);
            }

            m_SelectedObject = other.gameObject;
            m_SelectedObject.GetComponent<IInteractableObject>().Touch(true);
            HapticPulse();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<IInteractableObject>() != null)
        {
            m_SelectedObject.GetComponent<IInteractableObject>().Touch(false);
            m_SelectedObject = null;
            HapticPulse();
        }
    }

    void HapticPulse()
    {
        //device = SteamVR_Controller.Input((int)trackedObject.index);
        device.TriggerHapticPulse(500); // 
    }

    public int PickUp(PickUp aObject)
    {
        PickUp pickUp = m_SelectedObject.GetComponent<PickUp>();

        if (pickUp == null)
        {
            pickUp = aObject;
            pickUp.transform.parent = gameObject.transform;
            pickUp.transform.localPosition = Vector3.zero;

            m_ObjectInHand = Instantiate(pickUp.m_ObjectInHand, transform) as GameObject;
            pickUp.gameObject.SetActive(false);
        }
        return 0;
    }

    public int Drop()
    {
        if (m_ObjectInHand != null)
        {
            m_PickUp.gameObject.SetActive(true);
            Destroy(m_ObjectInHand);
            m_PickUp.transform.parent = null;
            m_PickUp = null;
        }

        return 0;
    }

}
