using UnityEngine;
using System.Collections;

public class ExtinguisherSpray : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Extinguishable")
        {
            other.gameObject.transform.localScale -=
            ((other.gameObject.transform.localScale * Time.deltaTime) * (CorrectExtinguisher ? 1 : -1));
        }
    }

    public bool CorrectExtinguisher;
}