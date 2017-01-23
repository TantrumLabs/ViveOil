using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ToScoreScene : MonoBehaviour
{
    [SerializeField] GameObject m_viveBox;
    [SerializeField] string m_sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_viveBox)
        {
            var v = GameObject.FindObjectsOfType<ScoreElement>();

            foreach(var i in v)
            {
                i.transform.parent = null;
                DontDestroyOnLoad(i.gameObject);
            }

            SceneManager.LoadScene(m_sceneName);
        }
    }
}
