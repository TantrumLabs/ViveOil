using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExitRoom : MonoBehaviour
{
    public List<GameObject> m_exitObjects = new List<GameObject>();

    [ContextMenu("Turn On Exit")]
    public void TurnOnExit()
    {
        foreach(GameObject g in m_exitObjects)
        {
            g.SetActive(true);
        }
    }
}
