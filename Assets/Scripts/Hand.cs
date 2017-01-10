using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour
{
    public PickUp m_InHand;

    public int Interact()
    {
        return 0;
    }

    public int PickUp(PickUp aObject)
    {
        m_InHand = aObject;
        m_InHand.transform.parent = gameObject.transform;
        m_InHand.transform.localPosition = Vector3.zero;

        Instantiate(m_InHand.m_ObjectInHand, transform);
        m_InHand.gameObject.SetActive(false);

        return 0;
    }
    
    public int Drop()
    {
        for(int i = 0; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i) == m_InHand.m_ObjectInHand)
            {
                m_InHand.gameObject.SetActive(true);
                Destroy(transform.GetChild(i));
                m_InHand.transform.parent = null;
            }
        }

        return 0;
    }

    public int ResetInHand()
    {
        return 0;
    }
}