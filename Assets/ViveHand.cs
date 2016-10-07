using UnityEngine;
using System.Collections;

public class ViveHand : MonoBehaviour
{
    [SerializeField] bool hapticOnStay;


    GameObject viveControllerModel;
    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObject;

	// Use this for initialization
	void Start ()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void onTriggerEnter(Collider c)
    {
        if (c.tag == "Interactable")
        {
            HapticPulse();
               
        }
    }

    void HapticPulse()
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);
        device.TriggerHapticPulse(500); // 
    }
}
