using UnityEngine;
using System.Collections;

public class HeatMiniGame : MonoBehaviour
{
    private Animation m_anim;

    private bool m_tempClimb = true;

    [SerializeField]
    Lever m_Lever;

    [SerializeField]
    float m_minTemp = 0;

    [SerializeField]
    float m_maxTemp = 0;

    [SerializeField]
    float m_currentTemp = 0;

    [SerializeField]
    Vector2 GoalRange;

    void Start()
    {
        m_anim = GetComponent<Animation>();
        m_anim.Play("NeedleTurn");
        m_anim["NeedleTurn"].speed = 0;
    }

    void FixedUpdate()
    {
        if (m_currentTemp < m_maxTemp && m_tempClimb)
        {
            HeatUp(1);
        }

        if (m_Lever.CurrentPercent() >= 0.6f)
        {
            m_tempClimb = false;
            if (m_Lever.CurrentPercent() > 0.8f)
                HeatUp(4);
            else
                HeatUp(2);
        }

        else if (m_Lever.CurrentPercent() <= 0.4f)
        {
            m_tempClimb = false;
            if (m_Lever.CurrentPercent() < 0.2f)
                CoolOff(4);
            else
                CoolOff(2);
        }

        else
            m_tempClimb = true;

        float t = (m_currentTemp - m_minTemp) / (m_maxTemp - m_minTemp);
        SeekNeedleAnimation(t);
    }

    void SeekNeedleAnimation(float seekpoint)
    {
        m_anim["NeedleTurn"].normalizedTime = seekpoint;
    }

    void HeatUp(float hotMod)
    {
        m_currentTemp += Time.deltaTime * (6 * hotMod);
    }

    void CoolOff(float coolMod)
    {
        m_currentTemp -= Time.deltaTime * (6 * coolMod);
    }
}
