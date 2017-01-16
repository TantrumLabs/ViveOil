using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SpringHandle : Interactable
{
    Vector3 m_BasePos;
    bool grabbed = false;
    SteamVR_TrackedController m_GrabbedHand;
    List<SteamVR_TrackedController> m_TouchingCollider = new List<SteamVR_TrackedController>();
    
    void Start()
    {
        m_BasePos = transform.localPosition;

        m_OnInteraction.AddListener(Interact);
    }

    private void Update()
    {
        if (m_GrabbedHand == null)  // If grabbedHand is not populated, break
            return;

        if(!m_GrabbedHand.triggerPressed)
        {
            grabbed = false;
            transform.localPosition = m_BasePos;
            m_GrabbedHand = null;
        }

        else
        {
            transform.position = m_GrabbedHand.transform.position;
        }
    }

    public void Interact()
    {
        grabbed = true;

        foreach (SteamVR_TrackedController v in m_TouchingCollider)
        {
            if (v.triggerPressed)
            {
                m_GrabbedHand = v;
            }
        }
    }

    ////////////////////////////////////////

    private void OnTriggerEnter(Collider other)
    {
        GameObject g = other.gameObject;
        if(g.GetComponent<SteamVR_TrackedController>())
        {
            m_TouchingCollider.Add(g.GetComponent<SteamVR_TrackedController>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SteamVR_TrackedController sc = other.gameObject.GetComponent<SteamVR_TrackedController>();
        if(sc)
            if (m_TouchingCollider.Contains(sc))
                m_TouchingCollider.Remove(sc);
        
    }
}
