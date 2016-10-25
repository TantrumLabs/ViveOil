using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    private float originalScale;
    FireManager fm;
    [SerializeField] float killFloat = 0f;
    public bool lit = true;
    bool toBig = false;

    void Awake()
    {
        originalScale = transform.localScale.magnitude;
        fm = GameObject.FindObjectOfType<FireManager>();
    }

	void Update ()
    {
        if (transform.localScale.magnitude >= 5 && lit)
        {
            lit = false;
            fm.Lose();
        }

        if (transform.localScale.magnitude < killFloat)
        {
            lit = false;
            gameObject.SetActive(false);
        }

        if(transform.localScale.magnitude < originalScale)
        {
            transform.localScale += (transform.localScale * (Time.deltaTime / 2));
        }
	}

    public void ResetFire()
    {
        gameObject.transform.localScale = new Vector3(2,2,2);
        lit = true;
        gameObject.SetActive(true);
    }
    
}
