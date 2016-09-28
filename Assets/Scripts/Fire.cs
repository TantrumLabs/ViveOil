using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
	void Update ()
    {
        if (transform.localScale.magnitude < 0.1f)
            Destroy(gameObject);

        if(transform.localScale.magnitude < Mathf.Sqrt(3))
        {
            transform.localScale += (transform.localScale * (Time.deltaTime / 10));
        }
	}
}
