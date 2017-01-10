using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public enum e_Type
    {
        INTERACTABLE,
        PICKUP,
    }

    public GameObject m_ObjectInHand;
    public e_Type m_Type;

    public UnityEngine.Events.UnityEvent m_OnTouch;
    public UnityEngine.Events.UnityEvent m_OnInteraction;

    void Awake()
    {
        if (m_ObjectInHand == null)
            m_ObjectInHand = gameObject;
    }
}