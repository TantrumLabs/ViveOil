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

public enum eFireType
{
    WOOD,
    ELECTRICAL,
    FLAMMABLELIQUID,
    GASEOUS,
    METAL
}

public class Fire : MonoBehaviour
{
    /// <summary>
    /// The original size of the fire
    /// </summary>
    private float m_OriginalScale;

    /// <summary>
    /// The current size of the fire
    /// </summary>
    private float m_CurrentScale
    { get { return transform.localScale.magnitude; } }

    /// <summary>
    /// The smallest a fire can be without going out
    /// </summary>
    [SerializeField] private float m_MinSize = 0f;

    /// <summary>
    /// The largest a fire can be without loosing
    /// </summary>
    [SerializeField] private float m_MaxSize = 0f;

    /// <summary>
    /// Is the fire currently lit
    /// </summary>
    public bool m_IsLit = true;

    /// <summary>
    /// The type of fire (wood, gas, etc) used for extinguishing
    /// </summary>
    public eFireType m_FireType;

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
