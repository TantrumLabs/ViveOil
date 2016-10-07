using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextWindow : MonoBehaviour
{
    [SerializeField] Text textValue;
    Image textWindow;
    bool inUse = false;
    Animation anim;
    
    void Start()
    {
        anim = GetComponent<Animation>();
        textWindow = GetComponent<Image>();
    }

    [ContextMenu("Test")]
    public void Tester()
    {
        PushText("This is a test of the text crawl system. ksbfkshbfkjsbfgkjbskfgjbskjfgbskhjgb");
    }

    public void PushText(string s)
    {
        textWindow.enabled = true;
        textValue.enabled = true;
        anim.Play("TextWindowOpen");
        StartCoroutine(FillText(s));
    }
       
    IEnumerator FillText(string s)
    {
        int size = s.Length;
        int i = 0;

        textValue.text = ""; 

        while(i < size)
        {
            textValue.text += s[i];
            i++;
            yield return new WaitForSeconds(0.05f);
        }

        float time = 0;
        while(time <= 5)
        {
            time += Time.deltaTime;
            yield return null;
        }
        textWindow.enabled = false;
        textValue.enabled = false;

    }                   
}
