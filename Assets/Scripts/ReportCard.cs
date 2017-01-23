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
        GatherScores();
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
            GameObject g = Instantiate(m_scoreCardPrefab, gameObject.transform) as GameObject;
            g.GetComponent<ScoreCard>().LoadScoreCard(se);
            g.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            g.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
            g.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
            g.GetComponent<RectTransform>().localPosition = new Vector3(0, t, 0);
            g.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, t, 0);
            g.GetComponent<RectTransform>().localRotation = new Quaternion(0,0,0,0);

            totalScored += se.m_actualScore;
            totalPossible += se.m_possibleScore;

            t -= 55;
            yield return new WaitForSeconds(0.5f);
        }

        t -= 20;

        ScoreElement total = new ScoreElement("Total", totalPossible, "Let's do better next time.", 90);
        total.SetScore(totalScored);
        GameObject g2 = Instantiate(m_scoreCardPrefab, gameObject.transform) as GameObject;
        g2.transform.SetParent(gameObject.transform);
        g2.GetComponent<ScoreCard>().LoadScoreCard(total);
        g2.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        g2.GetComponent<RectTransform>().localPosition = new Vector3(0, t, 0);
        g2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, t, 0);
        g2.GetComponent<RectTransform>().localRotation = new Quaternion(0, 0, 0, 0);
    }
}
