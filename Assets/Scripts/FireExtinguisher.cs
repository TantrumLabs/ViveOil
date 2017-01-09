using UnityEngine;
using System.Collections;

public class FireExtinguisher : MonoBehaviour
{
    AudioSource audio;
    bool playAudio = false;
    Collider SprayNozzle;
    ParticleSystem SprayFoam;
    EllipsoidParticleEmitter steamParticleSystem;
    SteamVR_TrackedController leftController;
    SteamVR_TrackedController rightController;

    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;

    private float m_MaxSpray;
    public float m_CurrentSpray;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        leftController  = GameObject.FindObjectOfType<SteamVR_ControllerManager>().left.GetComponent<SteamVR_TrackedController>();
        rightController = GameObject.FindObjectOfType<SteamVR_ControllerManager>().right.GetComponent<SteamVR_TrackedController>();
        trackedObject = rightController.gameObject.GetComponent<SteamVR_TrackedObject>();
        SprayNozzle = this.transform.GetComponentInChildren<Collider>();
        SprayFoam = this.transform.GetComponentInChildren<ParticleSystem>();
        
        SetSpray(false);

        m_MaxSpray = m_CurrentSpray;
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);

        if (leftController.triggerPressed && m_CurrentSpray > 0)
        {
            SetSpray(true);
            device.TriggerHapticPulse(1000);
        }

        else
        {
            SetSpray(false);
        }

        if (playAudio && !audio.isPlaying)
            audio.Play();
        
        if (playAudio == false)
            audio.Stop();
    }

    public void SetSpray(bool active)
    {
        SprayNozzle.enabled = active;

        switch (active)
        {
            case true:
                SprayFoam.Play();
                playAudio = true;
                m_CurrentSpray -= Time.deltaTime;
                break;
            case false:
                SprayFoam.Stop();
                playAudio = false;
                break;
        }
    }

    public void Refresh()
    {
        m_CurrentSpray = m_MaxSpray;
    }
}
