using UnityEngine;
using System.Collections;

public class AnimateExtinguisher : MonoBehaviour
{
    [SerializeField]Animator anim;
    SteamVR_TrackedController controller
    {
        get
        {
            return transform.parent.GetComponent<SteamVR_TrackedController>();
        }
    }

    void Update ()
    {
        if(controller != null)
            anim.SetBool("TriggerPressed", controller.triggerPressed);
	}
}
