/*  Creator: Eric Z Mouledoux
 *  Contact: Eric@TantrumLab.com
 *  
 *  Usage:
 *  
 *  Notes:
 * 
 */

using UnityEngine;
using System.Collections.Generic;

public class GameFlow : MonoBehaviour
{
    private IEvent m_ActiveEvent;
    [SerializeField] private List<IEvent> m_Events = new List<IEvent>();

	void Start ()
    {
        m_ActiveEvent = m_Events.Count > 0 ? m_Events[0] : null;

        if (m_ActiveEvent == null)
        {
            Destroy(this);
        }
        else
        {
            for(int i = 1; i < m_Events.Count; ++i)
            {
                m_Events[i].self.SetActive(false);
            }
        }
	}
	
	void Update ()
    { 
        if(m_ActiveEvent.isComplete)
        {
            m_Events.Remove(m_ActiveEvent);
            m_ActiveEvent = m_Events[0];
        }
	}
}
