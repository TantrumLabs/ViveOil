﻿using UnityEngine;
using System.Collections;

enum ExtinguisherType
{
    CO2,
    POWDER,
    FOAM,
    WATER
}

public class ExtinguisherSpray : MonoBehaviour
{
    [SerializeField] ExtinguisherType type;

    [SerializeField]private bool m_shake;
    private float m_lastYRotation = 0;

    //Test
    [Range(0, 1)]
    [SerializeField]float shakeBreak = 0.5f;

    void Start()
    {
        StartCoroutine(Extinguish());
    }

    IEnumerator Extinguish()
    {
        while(true)
        {
            float currentYRotation = gameObject.transform.rotation.y;

            m_shake = (Mathf.Abs(currentYRotation - m_lastYRotation) > shakeBreak);
            Debug.Log(Mathf.Abs(currentYRotation - m_lastYRotation));
            m_lastYRotation = currentYRotation;

            yield return new WaitForSeconds(.1f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.GetComponent<Fire>() != null) && m_shake)
        {
            DownFire(other);
        }
    }

    void DownFire(Collider other)
    {

        Fire F = other.gameObject.GetComponent<Fire>();

        if (F != null)
        {
            if (Mathf.Abs(transform.position.y - F.transform.position.y) < 0.25)
            {
                Debug.Log("Fire");
                #region Fire check
                switch (F.m_FireType)
                {
                    case eFireType.WOOD:
                        other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * 5);
                        break;

                    case eFireType.ELECTRICAL:
                        if (type == ExtinguisherType.FOAM || type == ExtinguisherType.WATER)
                            other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * -0.8f);
                        else
                            other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * 0.8f);
                        break;

                    case eFireType.FLAMMABLELIQUID:
                        if (type == ExtinguisherType.WATER)
                            other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * -1);
                        else
                            other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * 0.8f);
                        break;

                    case eFireType.GASEOUS:
                        if (type == ExtinguisherType.FOAM || type == ExtinguisherType.WATER)
                            other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * -1);
                        else
                            other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * 0.8f);
                        break;

                    case eFireType.METAL:
                        if (type == ExtinguisherType.FOAM || type == ExtinguisherType.WATER)
                            other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * -1f);
                        else
                            other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * 0.8f);
                        break;

                    default:
                        break;

                }
                #endregion
            }
        }
    }
}