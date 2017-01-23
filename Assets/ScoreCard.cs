using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCard : MonoBehaviour
{
    [SerializeField]
    Text m_scoreName;

    [SerializeField]
    Text m_score;

    [SerializeField]
    Text m_maxScore;

    [SerializeField]
    Text m_feebBack;


    public void LoadScoreCard(ScoreElement se)
    {
        m_scoreName.text    = se.m_name;
        m_score.text        = se.m_actualScore.ToString();
        m_maxScore.text     = se.m_possibleScore.ToString();
        m_feebBack.text     = se.Feedback();
    } 

}
