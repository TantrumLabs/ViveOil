using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lever : MonoBehaviour
{
    [SerializeField]
    float m_min = 0;

    [SerializeField]
    float m_max = 0;

    float percent = 0;

    void FixedUpdate()
    {
        float current = ( 360 / Mathf.PI) * gameObject.transform.localRotation.x;
        percent = (current - m_min) / (m_max - m_min);
    }

    public float CurrentPercent()
    {
        return percent;
    }

}
