using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExtinguisherManager : MonoBehaviour
{
    public List<GameObject> extinguishers = new List<GameObject>();

	void Awake()
    {
        foreach(Transform child in transform)
        {
            if (child.gameObject.GetComponent<PickUpObject>() != null)
                extinguishers.Add(child.gameObject);
        }
    }

    //public void ResetFireExtinguisher()
    //{
    //    foreach(GameObject g in extinguishers)
    //    {
    //        g.GetComponent<PickUpObject>().PutBack();
    //    }
    //    GameObject[] t = GameObject.FindGameObjectsWithTag("PickUp");
    //    foreach(GameObject g in t)
    //    {
    //        Destroy(g);
    //    }

    //    SteamVR_RenderModel[] m = FindObjectsOfType<SteamVR_RenderModel>();
    //    foreach(SteamVR_RenderModel rm in m)
    //    {
    //        rm.enabled = true;
    //    }
    //}
}
