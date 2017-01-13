using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lever : MonoBehaviour
{
    public Text text;

    [SerializeField]
    float m_min = 0;

    [SerializeField]
    float m_max = 0;

    int percent = 0;

    void FixedUpdate()
    {
        float current = ( 360 / Mathf.PI) * gameObject.transform.localRotation.x;
        percent = (int)(((current - m_min) / (m_max - m_min)) * 100);


    }

    int CurrentPercent()
    {
        return percent;
    }

}
