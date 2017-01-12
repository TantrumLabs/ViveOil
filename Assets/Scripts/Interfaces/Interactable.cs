using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public bool m_IsPickUp;
    public Vector3 PickUpOffset;

    public UnityEngine.Events.UnityEvent m_OnTouch;
    public UnityEngine.Events.UnityEvent m_OffTouch;
    public UnityEngine.Events.UnityEvent m_OnInteraction;
    public UnityEngine.Events.UnityEvent m_OffInteraction;
}