using UnityEngine;
using System.Collections;

public class FireExtinguisher : MonoBehaviour
{
    public Collider SprayNozzle;
    public ParticleSystem SprayFoam;
    [SerializeField] SteamVR_TrackedController LeftController;
    //bool triggerDown = false;

    void Start()
    {
        SetSpray(false);
    }

    void Update()
    {
        if (LeftController.triggerPressed)
        {
            SetSpray(true);
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
