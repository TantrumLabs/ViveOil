using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public bool m_IsPickUp;
    public Vector3 m_PickUpOffsetPOS;
    public Vector3 m_PickUpOffsetROT;

    public UnityEngine.Events.UnityEvent m_OnTouch;
    public UnityEngine.Events.UnityEvent m_OffTouch;

    public UnityEngine.Events.UnityEvent m_OnPickUp;
    public UnityEngine.Events.UnityEvent m_OnDrop;

    public UnityEngine.Events.UnityEvent m_OnInteraction;
    public UnityEngine.Events.UnityEvent m_OffInteraction;
}