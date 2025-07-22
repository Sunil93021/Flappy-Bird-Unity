using System;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;
    private static  ScoreKeeper instance;
    public event EventHandler<EventArgs> OnScoreChanged;
    private void Awake()
    {
        ManageSingleton();
    }
    private void ManageSingleton() { 
        
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
        OnScoreChanged?.Invoke(this, new EventArgs());
    }

    public int GetScore()
    {
        return score;
    }
    public static ScoreKeeper GetInstance()
    {
        return instance;
    }
}
