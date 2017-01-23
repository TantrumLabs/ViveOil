using UnityEngine;
using System.Collections;

public class HeatMiniGame : MonoBehaviour
{
    [System.Serializable]
    public struct TempRange { public int min, max; }

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
    TempRange m_GoalRange;

    [SerializeField]
    Light m_alarmLight;

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


        if ((m_currentTemp < m_GoalRange.min || m_currentTemp > m_GoalRange.max) && !m_alarmLight.enabled)
        {
            StartCoroutine(LightBlink());
        }
    }

    void SeekNeedleAnimation(float seekpoint)
    {
        m_anim["NeedleTurn"].normalizedTime = seekpoint;
        m_anim.Play();
    }

    void HeatUp(float hotMod)
    {
        if (m_currentTemp < m_maxTemp)
            m_currentTemp += Time.deltaTime * (6 * hotMod);
    }

    void CoolOff(float coolMod)
    {
        if(m_currentTemp > 0)
            m_currentTemp -= Time.deltaTime * (6 * coolMod);
    }

    IEnumerator LightBlink()
    {
        m_alarmLight.enabled = true;
        float lightIntesity = m_alarmLight.intensity;
        bool grow = true;

        while ( m_currentTemp < m_GoalRange.min || m_currentTemp > m_GoalRange.max)
        {
            if (grow)
            {
                if (m_alarmLight.intensity < lightIntesity)
                    m_alarmLight.intensity += Time.deltaTime * 3;
                else
                    grow = false;
            }
            else
            {
                if (m_alarmLight.intensity > 0)
                    m_alarmLight.intensity -= Time.deltaTime * 3;
                else
                    grow = true;
            }

            yield return null;
        }

        m_alarmLight.intensity = lightIntesity;
        m_alarmLight.enabled = false;
    }
}
