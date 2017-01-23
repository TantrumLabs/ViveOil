using UnityEngine;
using System.Collections;

public class ScoreOverTime : MonoBehaviour
{
    [SerializeField] float m_minTime = 0;
    [SerializeField] float m_maxTime = 0;
    float elapsedTime = 0;

    int negative = 0;

    public void StartTimer()
    {
        elapsedTime = m_maxTime - m_minTime;
        StartCoroutine(StartCountDown());
    }
    
    public void StopTimer()
    {
        StopAllCoroutines();
        MakeScoreElement();
    }

    public void MakeScoreElement()
    {
        ScoreElement s = GetComponent<ScoreElement>();
        int i =  (int)(s.m_possibleScore * ((elapsedTime / (m_maxTime - m_minTime))));
        i -= negative;
        if (i < 0)
            i = 0;
        s.SetScore(i);
    }

    public void ReduceScore(int n)
    {
        negative += n;
    }

    IEnumerator StartCountDown()
    {
        float timer = 0;

        while(elapsedTime > 0)
        {
            float dt = Time.deltaTime;
            timer += dt;

            if (timer > m_minTime)
                elapsedTime -= dt;

            yield return null;
        }
    }

}
