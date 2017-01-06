/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireManager : MonoBehaviour
{
    [SerializeField] List<Fire> fire;
    [SerializeField] TextWindow text;
    [SerializeField] Vector3 resetPos;
    bool inProgress = true;
    [SerializeField] GameObject camrig;
    [SerializeField] List<GameObject> winButtons;


    [SerializeField] string loseMessage;
    [SerializeField] string winMessage;

    // Update is called once per frame
    void Update ()
    {
        CheckForWin();
	}

    void CheckForWin()
    {
        bool firesStillActive = false;

        foreach (Fire f in fire)
        {
            if (f.m_IsLit)
            {
                firesStillActive = true;
            }
        }

        if (!firesStillActive)  // if no fires are lit
        {
            if (inProgress)
                Win();
        }
    }

    void Win()
    {
        inProgress = false;
        text.PushText(winMessage);
        foreach(GameObject g in winButtons)
        {
            g.SetActive(true);
        }
    }

    public void Lose()
    {
        camrig.transform.position = resetPos; // Hall way just before fire room
        ResetFires();
        text.PushText(loseMessage);
    }

    public void ResetFires()
    {
        foreach(Fire f in fire)
        {
            f.ResetFire();
        }
    }
}*/

using UnityEngine;
using System.Collections.Generic;

public class FireManager : MonoBehaviour
{
    private bool m_InProgress = true;

    [SerializeField] private GameObject m_CameraRig;
    [SerializeField] private Vector3 m_ResetPos;
    [SerializeField] private TextWindow m_TextWindow;
    [SerializeField] private List<Fire> m_Fires = new List<Fire>();
    [SerializeField] private List<GameObject> m_WinButtons = new List<GameObject>();

    [SerializeField] private string m_LoseMessage;
    [SerializeField] private string m_WinMessage;

    void Awake()
    {
        Fire[] fireChildren = GetComponentsInChildren<Fire>();
        foreach (Fire f in fireChildren)
        {
            m_Fires.Add(f);
        }
    }

    void Update()
    {
        if(m_InProgress)
            CheckForWin();
    }

    private int CheckForWin()
    {
        foreach (Fire f in m_Fires)
        {
            if (f.m_IsLit)
            {
                return 1;
            }
        }
        
        Win();
        return 0;
    }

    private void Win()
    {
        m_InProgress = false;
        m_TextWindow.PushText(m_WinMessage);
        foreach (GameObject g in m_WinButtons)
        {
            g.SetActive(true);
        }
    }

    public void Lose()
    {
        m_CameraRig.transform.position = m_ResetPos;
        ResetFires();
        m_TextWindow.PushText(m_LoseMessage);
    }

    public void ResetFires()
    {
        m_InProgress = true;
        foreach (Fire f in m_Fires)
        {
            f.ResetFire();
        }
    }
}