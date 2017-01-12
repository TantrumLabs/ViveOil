using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ReportCard : MonoBehaviour
{
    /// <summary>
    /// Text UI that will display the Score results
    /// </summary>
    //[SerializeField]
    //private Text m_scoreDisplay;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject m_scoreCardPrefab;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private List<ScoreElement> m_scores = new List<ScoreElement>();

    void Start()
    {
        StartCoroutine(PrintScoreCards());
    }

    // Test
    [ContextMenu("Test: Gather Scores")]
    void GatherScores()
    {
        ScoreElement[] se = FindObjectsOfType<ScoreElement>();

        foreach (ScoreElement s in se)
        {
            m_scores.Add(s);
        }
    }

    //[ContextMenu("Test")]
    //void WriteScoreCard()
    //{
    //    string output = "\n";
    //    int score = 0;
    //    int possibleScore = 0;
    //    foreach(ScoreElement s in m_scores)
    //    {
    //        output += s.PrintScore();
    //        score += s.m_actualScore;
    //        possibleScore += s.m_possibleScore;
    //    }

    //    output += "\n\nOverall Score: \t" + score.ToString() + " / " + possibleScore.ToString(); 
    //    m_scoreDisplay.text = output;
    //}

    bool SubmitScore(ScoreElement score)
    {
        m_scores.Add(score);
        return true;
    }

    IEnumerator PrintScoreCards()
    {
        int t = -15;

        int totalScored = 0;
        int totalPossible = 0;

        foreach(ScoreElement se in m_scores )
        {
            GameObject g = Instantiate<GameObject>(m_scoreCardPrefab);
            g.transform.SetParent(gameObject.transform);
            g.GetComponent<ScoreCard>().LoadScoreCard(se);
            g.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,t,0);

            totalScored += se.m_actualScore;
            totalPossible += se.m_possibleScore;

            t -= 55;
            yield return new WaitForSeconds(0.5f);
        }

        t -= 20;

        ScoreElement total = new ScoreElement("Total", totalPossible, "Let's do better next time.", 60);
        total.SetScore(totalScored);
        GameObject g2 = Instantiate<GameObject>(m_scoreCardPrefab);
        g2.transform.SetParent(gameObject.transform);
        g2.GetComponent<ScoreCard>().LoadScoreCard(total);
        g2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, t, 0);


    }
}
