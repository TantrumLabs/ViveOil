using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class ToSceneButton : MonoBehaviour
{
    [SerializeField]
    string m_sceneName;
    
    
	public void ToScene()
    {
        var Scores = GameObject.FindObjectsOfType<ScoreElement>();
        foreach(var v in Scores)
        {
            Destroy(v.gameObject);
        }

        SceneManager.LoadScene(m_sceneName);
    }
}
