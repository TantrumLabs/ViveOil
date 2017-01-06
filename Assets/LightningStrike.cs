using UnityEngine;
using System.Collections;

public class LightningStrike : MonoBehaviour
{
    Light m_LightningSource;
    [SerializeField] AudioClip m_Thunder;
    AudioSource m_aud;

    // Use this for initialization
    void Start()
    {
        m_LightningSource = GetComponent<Light>();
        m_aud = GetComponent<AudioSource>();
    }

    public void Stike()
    {
        m_aud.PlayOneShot(m_Thunder);
        StartCoroutine(LightningFlash());
    }

    IEnumerator LightningFlash()
    {
        float timer = 0;

        while(timer < 0.5f)
        {
            float lite = Random.Range(0, 4);
            if(lite == 1)
            {
                m_LightningSource.enabled = true;
                yield return new WaitForSeconds(.01f);
                m_LightningSource.enabled = false;
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }


}
