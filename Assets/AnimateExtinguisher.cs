using UnityEngine;
using System.Collections;

public class AnimateExtinguisher : MonoBehaviour
{
    [SerializeField] Animator anim;
    SteamVR_TrackedController controller;

    void Start()
    {
        controller = GetComponent<SteamVR_TrackedController>();
    }

    void Update ()
    {
        anim.SetBool("TriggerPressed", controller.triggerPressed);
	}
}
