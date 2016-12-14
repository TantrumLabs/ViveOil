using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeatBuildUp : MonoBehaviour
{
    float temperature = 120;
    public Text outPut;

    public GameObject Light;

    void Start()
    {
        StartCoroutine(HeatClimb());
    }

    public void Vent()
    {
        StartCoroutine(CoolDown());
    }

    IEnumerator HeatClimb()
    {
        string text = "";

        while (temperature <= 675)
        {
            temperature += 1f;
            text = "Temperature \n" + temperature.ToString() + "\t\t° C";

            outPut.text = text;

            yield return new WaitForSeconds(0.09f);
        }
        text = "Temperature \n" + temperature.ToString() + "\t\t°C \nOverHeated";
        outPut.text = text;
    }

    IEnumerator CoolDown()
    {
        string text = "";
        while (temperature >= 300)
        {
            temperature -= 3f;

            text = "Temperature \n" + temperature.ToString() + "\t\t°C";
            outPut.text = text;
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(HeatClimb());
    }
}
