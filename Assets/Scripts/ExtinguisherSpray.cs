using UnityEngine;
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

    void OnTriggerStay(Collider other)
    {
        Fire F = other.gameObject.GetComponent<Fire>();

        if(F != null)
        {
            #region Fire check
            switch (F.m_FireType)
            {
                case eFireType.WOOD:
                    other.gameObject.transform.localScale -= ((other.gameObject.transform.localScale * Time.deltaTime) * 0.8f);
                    break;

                case eFireType.ELECTRICAL:
                    if(type == ExtinguisherType.FOAM || type == ExtinguisherType.WATER)
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