using UnityEngine;
using System.Collections;

public class FireExtinguisher : MonoBehaviour
{
    public Collider SprayNozzle;
    public ParticleSystem SprayFoam;
    [SerializeField] SteamVR_TrackedController leftController;
    [SerializeField] SteamVR_TrackedController rightController;

    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;

    void Start()
    {
        SetSpray(false);
        trackedObject = rightController.gameObject.GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);

        if (leftController.triggerPressed)
        {
            SetSpray(true);
            device.TriggerHapticPulse(500);
        }

        else
        {
            SetSpray(false);
        }
    }

    public void SetSpray(bool active)
    {
        SprayNozzle.enabled = active;

        switch (active)
        {
            case true:
                SprayFoam.Play();
                break;
            case false:
                SprayFoam.Stop();
                break;
        }
    }
}
