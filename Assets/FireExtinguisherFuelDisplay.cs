using UnityEngine;
using System.Collections;

public class FireExtinguisherFuelDisplay : MonoBehaviour
{
    Animation m_anim;
    [SerializeField] FireExtinguisher m_extinguisher;
    [SerializeField] Camera m_playerCam;

	void Start ()
    {
        m_anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float t = (m_extinguisher.m_CurrentSpray / m_extinguisher.m_MaxSpray);

        m_anim["ExtinguisherFuel"].normalizedTime = t;
        m_anim.Play();

        transform.LookAt(m_playerCam.gameObject.transform.position);
	}


}
