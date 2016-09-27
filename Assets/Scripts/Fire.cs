using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    void Awake()
    {
        originalScale = transform.localScale.magnitude;
    }

	void Update ()
    {
        if (transform.localScale.magnitude < 0.1f)
            Destroy(gameObject);

        if(transform.localScale.magnitude < originalScale)
        {
            transform.localScale += (transform.localScale * (Time.deltaTime / 2));
        }
	}

    private float originalScale;
}
