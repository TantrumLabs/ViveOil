using UnityEngine;
using System.Collections;

public class AnimateHands : MonoBehaviour {
    /*Test*/[SerializeField]SteamVR_TrackedController control;

    [SerializeField] GameObject m_Hand;
    Animator m_Anim;

	// Use this for initialization
	void Start () {
        m_Anim = m_Hand.GetComponent<Animator>();
	}

    void Update()
    {
        m_Anim.SetBool("Grab", control.triggerPressed);
        m_Anim.SetBool("Point", control.padPressed);
    }
}
