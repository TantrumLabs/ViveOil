using UnityEngine;
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
            if (f.lit)
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
        text.PushText("Looks like the fire is out.\nGood work, but keep your eye out for any more trouble." );
        foreach(GameObject g in winButtons)
        {
            g.SetActive(true);
        }
    }

    public void Lose()
    {
        camrig.transform.position = resetPos; // Hall way just before fire room
        ResetFires();
        text.PushText("That was the wrong extinguisher to deal with an Electrical fire. Let's try again.");
    }

    public void ResetFires()
    {
        foreach(Fire f in fire)
        {
            f.ResetFire();
        }
    }
}
