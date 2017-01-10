using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour
{
    public PickUp m_InHand;
    private GameObject m_ObjectInHand;

    void OnTriggerEnter(Collider other)
    {
        PickUp p = other.GetComponent<PickUp>();
        if (p != null)
            PickUp(p);
    }

    public int Interact()
    {
        return 0;
    }

    public int PickUp(PickUp aObject)
    {
        if (m_InHand == null)
        {
            m_InHand = aObject;
            m_InHand.transform.parent = gameObject.transform;
            m_InHand.transform.localPosition = Vector3.zero;

            m_ObjectInHand = Instantiate(m_InHand.m_ObjectInHand, transform) as GameObject;
            m_InHand.gameObject.SetActive(false);
        }
        return 0;
    }
    
    public int Drop()
    {
        if(m_ObjectInHand != null)
        {
            m_InHand.gameObject.SetActive(true);
            Destroy(m_ObjectInHand);
            m_InHand.transform.parent = null;
            m_InHand = null;
        }

        return 0;
    }

    public int ResetInHand()
    {
        return 0;
    }
}