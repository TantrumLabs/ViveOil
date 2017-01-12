﻿using UnityEngine;
using System.Collections;

public class FireExtinguisher : MonoBehaviour
{
    AudioSource audio;
    bool playAudio = false;
    Collider SprayNozzle;
    ParticleSystem SprayFoam;
    EllipsoidParticleEmitter steamParticleSystem;

    SteamVR_TrackedController m_OnHand;
    SteamVR_TrackedController m_OffHand;

    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;

    private float m_MaxSpray = 0;
    [SerializeField] float m_CurrentSpray = 0;

    void Start()
    {
        m_MaxSpray = m_CurrentSpray;

        audio = gameObject.GetComponent<AudioSource>();
        //leftController  = FindObjectOfType<SteamVR_ControllerManager>().left.GetComponent<SteamVR_TrackedController>();
        //rightController = FindObjectOfType<SteamVR_ControllerManager>().right.GetComponent<SteamVR_TrackedController>();
        //trackedObject = rightController.gameObject.GetComponent<SteamVR_TrackedObject>();
        //SprayNozzle = transform.GetComponentInChildren<Collider>();
        
        SprayFoam = transform.GetComponentInChildren<ParticleSystem>();
        SprayNozzle = SprayFoam.gameObject.GetComponent<Collider>();

        SetSpray(false);
    }

    void Update()
    {
        //device = SteamVR_Controller.Input((int)trackedObject.index);

        if (m_CurrentSpray <= 0)
        {
            SetSpray(false);
        }

        if (playAudio && !audio.isPlaying)
            audio.Play();
        
        if (playAudio == false)
            audio.Stop();
    }

    void OnEnable()
    {
        Refresh();
    }

    public void SetSpray(bool active)
    {
        if (m_CurrentSpray <= 0)
            return;

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
        //m_CurrentSpray = m_MaxSpray;
    }
}
