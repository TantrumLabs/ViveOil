using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    [SerializeField] float killFloat = 0f;
    void Awake()
    {
        originalScale = transform.localScale.magnitude;
    }

	void Update ()
    {
        if (transform.localScale.magnitude < killFloat)
            Destroy(gameObject);

        if(transform.localScale.magnitude < originalScale)
        {
            transform.localScale += (transform.localScale * (Time.deltaTime / 2));
        }
	}

    private float originalScale;
}
