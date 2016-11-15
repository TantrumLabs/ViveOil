using UnityEngine;
using System.Collections;

public class ToTheFire : MonoBehaviour
{
    [SerializeField] GameObject viveRig;
    [SerializeField] GameObject viveBox;
    [SerializeField] Vector3 firePos;
    [SerializeField] TextWindow tw;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == viveBox)
        {
            viveRig.transform.position = firePos;
            tw.PushText("There seems to be an electrical fire up ahead. ");
        }
    }

}
