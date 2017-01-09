using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ReportCard : MonoBehaviour
{
    /// <summary>
    /// Text UI that will display the Score results
    /// </summary>
    [SerializeField]
    private Text m_scoreDisplay;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private List<ScoreElement> m_scores = new List<ScoreElement>();

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

    [ContextMenu("Test")]
    void WriteScoreCard()
    {
        string output = "\n";
        int score = 0;
        int possibleScore = 0;
        foreach(ScoreElement s in m_scores)
        {
            output += s.PrintScore();
            score += s.m_actualScore;
            possibleScore += s.m_possibleScore;
        }

        output += "\n\nOverall Score: \t" + score.ToString() + " / " + possibleScore.ToString(); 
        m_scoreDisplay.text = output;
    }
}
