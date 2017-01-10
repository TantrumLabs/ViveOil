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
        Instantiate(aObject.m_ObjectInHand, transform);

        return 0;
    }
    
    public int Drop()
    {
        for(int i = 0; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i) == m_InHand.m_ObjectInHand)
                transform.GetChild(i).transform.parent = null;
        }

        return 0;
    }

    public int ResetInHand()
    {
        return 0;
    }
}