/*using UnityEngine;
using System.Collections;

public enum FireType
{
    WOOD,
    ELECTRICAL,
    FLAMMABLELIQUID,
    GASEOUS,
    METAL
}

public class Fire : MonoBehaviour
{
    private float originalScale;
    FireManager fm;
    public FireType fireType;
    [SerializeField] float killFloat = 0f;
    public bool lit = true;
    bool toBig = false;

    void Awake()
    {
        originalScale = transform.localScale.magnitude;
        fm = transform.parent.GetComponent<FireManager>();
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
        gameObject.transform.localScale = new Vector3(1, 1, 1) * originalScale;
        lit = true;
        gameObject.SetActive(true);
    }
    
}*/

using UnityEngine;
using System.Collections;

public enum FireType
{
    WOOD,
    ELECTRICAL,
    FLAMMABLELIQUID,
    GASEOUS,
    METAL
}

public class Fire : MonoBehaviour
{
    private float m_OriginalScale;

    private float m_CurrentScale
    { get { return transform.localScale.magnitude; } }

    [SerializeField] private float m_MinSize = 0f;
    [SerializeField] private float m_MaxSize = 0f;

    public bool m_IsLit = true;

    public FireType m_FireType;

    void Awake()
    {
        m_OriginalScale = m_CurrentScale;
    }

	void Update ()
    {
        if (m_CurrentScale < m_MinSize)
        {
            m_IsLit = false;
        }

        if(m_CurrentScale < m_OriginalScale && m_IsLit)
        {
            transform.localScale += Vector3.one * (Time.deltaTime / 10);
        }
	}

    public void ResetFire()
    {
        gameObject.transform.localScale = Vector3.one * m_OriginalScale;
        m_IsLit = true;
        gameObject.SetActive(true);
    }
}
