using UnityEngine;
using System.Collections;

public class PullFireAlarm : Interactable
{
    bool m_pulled;
    [SerializeField] ScoreElement m_ScoreElement;

    private void Start()
    {
        m_OnInteraction.AddListener(Pull);
    }

    void Pull()
    {
        if(!m_pulled)
        {
            m_pulled = true;
            m_ScoreElement.SetScore(10);

        }
        
    }
    
}
