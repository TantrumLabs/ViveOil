using UnityEngine;
using System.Collections.Generic;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_Events = new List<GameObject>();
    private GameObject m_ActiveObject;
    private IEvent m_ActiveEvent;

    void Awake ()
    {
        GameFlow[] t = FindObjectsOfType<GameFlow>();
        for (int i = 0; i < t.Length; ++i)
        {
            if (t[i] != this)
            {
                Destroy(t[i]);
            }
        }
    }

    void Start ()
    {
	    foreach(GameObject g in m_Events)
        {
            if(g.GetComponent<IEvent>() == null)
            {
                m_Events.Remove(g);
            }
        }

        if (m_Events.Count == 0)
        {
            Destroy(this);
        }

        else
        {
            m_ActiveObject = m_Events[0];
            m_ActiveEvent = m_ActiveObject.GetComponent<IEvent>();
        }
	}
	
	void Update ()
    {
	    
	}
}
