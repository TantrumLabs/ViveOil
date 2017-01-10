using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{
    public GameObject m_ObjectInHand;

    void Awake()
    {
        if (m_ObjectInHand == null)
            m_ObjectInHand = gameObject;
    }

    public int Touch()
    {
        return 0;
    }
}