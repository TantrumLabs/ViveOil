using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    private float m_Timer = 0;
    private TriggeredEvent m_CurrentEvent;
    public List<TriggeredEvent> m_Events = new List<TriggeredEvent>();

    void Awake()
    {
        m_CurrentEvent = m_Events[0];
    }

    void Update()
    {
        if (m_CurrentEvent.nextEventDelay < 0)
        {
            return;
        }

        else
        {
            m_Timer += Time.deltaTime;

            if(m_Timer >= m_CurrentEvent.nextEventDelay)
            {
                TriggerNextEvent();
                m_Timer = 0;
            }
        }
    }

    public void TriggerNextEvent()
    {
        int cIndex = m_Events.FindIndex(i => i == m_CurrentEvent);
        TriggerEventAtIndex(cIndex + 1);
    }

    public void TriggerEventAtIndex(int aIndex)
    {
        if (aIndex >= m_Events.Count)
            return;

        m_CurrentEvent = m_Events[aIndex];
        m_CurrentEvent.RunEvent();
    }

}

[System.Serializable]
public class TriggeredEvent
{
    public UnityEngine.Events.UnityEvent TriggerEvent;
    public float nextEventDelay;

    public int RunEvent()
    {
        TriggerEvent.Invoke();
        return 0;
    }
}