using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    
    private ScoreKeeper scoreKeeper;
    private void Start()
    {
        if(scoreKeeper == null)
        {
            scoreKeeper = ScoreKeeper.GetInstance();
            scoreKeeper.OnScoreChanged += ScoreKeeper_OnScoreChanged;
            score.text = "Score : " + scoreKeeper.GetScore().ToString("000");

        }
        else
        {
            Debug.LogError("There is No ScoreKeeper Instance");
        }
    }

    private void ScoreKeeper_OnScoreChanged(object sender, System.EventArgs e)
    {
        score.text = "Score : " + scoreKeeper.GetScore().ToString("000");
    }

   
}
