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
}
