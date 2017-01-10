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
    private Interactable m_SelectedInteractable
    {
        get
        {
            return m_SelectedObject.GetComponent<Interactable>();
        }
    }

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        trackedHand = GetComponent<SteamVR_TrackedController>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    void Update()
    {
        if (m_SelectedObject == null)
        {
            return;
        }

        else if (trackedHand.triggerPressed && !trigger)
        {
            trigger = true;

            switch(m_SelectedInteractable.m_Type)
            {
                case Interactable.e_Type.INTERACTABLE:
                    m_SelectedInteractable.m_OnInteraction.Invoke();
                    break;
                case Interactable.e_Type.PICKUP:
                    PickUp(m_SelectedObject);
                    break;
            }

        }
        else if (!trackedHand.triggerPressed && trigger)
        {
            trigger = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            m_SelectedObject = other.gameObject;
            m_SelectedInteractable.m_OnTouch.Invoke();
            HapticPulse();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == m_SelectedObject)
        {
            m_SelectedObject = null;
            HapticPulse();
        }
    }

    void HapticPulse()
    {
        device.TriggerHapticPulse(500);
    }

    public int PickUp(GameObject aObject)
    {
        if (m_SelectedInteractable == null)
        {
            m_SelectedInteractable.transform.parent = gameObject.transform;
            m_SelectedInteractable.transform.localPosition = Vector3.zero;

            m_ObjectInHand = Instantiate(m_SelectedInteractable.m_ObjectInHand, transform) as GameObject;
            m_SelectedInteractable.gameObject.SetActive(false);
        }
        return 0;
    }

    public int Drop()
    {
        if (m_ObjectInHand != null)
        {
            m_SelectedObject.SetActive(true);
            Destroy(m_ObjectInHand);
            m_SelectedObject.transform.parent = null;
            m_SelectedObject = null;
        }

        return 0;
    }

}
