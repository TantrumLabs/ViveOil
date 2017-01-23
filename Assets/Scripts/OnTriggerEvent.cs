using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider))]

public class OnTriggerEvent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent m_Event;
	void Start ()
    {
        GetComponent<Collider>().isTrigger = true;
	}

    private void OnTriggerEnter(Collider other)
    {
        m_Event.Invoke();
    }
}
