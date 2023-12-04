using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum E_PerformanceLevel 
{
    Bad,
    Good,
    Perfect
}

public class ScoreManager : MonoBehaviour
{
    private int CurrentScore = 0;
    [SerializeField] private int Bad_Score = 0;
    [SerializeField] private int Good_Score = 1;
    [SerializeField] private int Perfect_Score = 2;

    [SerializeField] private TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        ScoreText.text = "Score: " + CurrentScore;
    }

    public int GetScore()
    {
        return CurrentScore;
    }

    public void UpdateScore(E_PerformanceLevel i_PL)
    {
        // Update score
        switch (i_PL) 
        {
            case E_PerformanceLevel.Good:
                CurrentScore += Good_Score;
                break;
            case E_PerformanceLevel.Perfect:
                CurrentScore += Perfect_Score;
                break;
            case E_PerformanceLevel.Bad:
                CurrentScore += Bad_Score;
                break;
        }

        // Update UI
        ScoreText.text = "Score: " + CurrentScore;
        Debug.Log("Current score: " + CurrentScore);
    }
}
