using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{   
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private int maxScore = 5;

    private int lastScoredPlayer = 0;

    private Vector2 currentScore = new Vector2();

    public static event Action ScoreHasChanged;

    public Vector2 CurrentScore
    {
        get { return currentScore; }
        set
        {
            currentScore = value;
            HandleGameOver();
            DisplayNewScore();
            ScoreHasChanged?.Invoke();
        }
    }

    private void Start() 
    {
        currentScore = new Vector2(0f, 0f);
        DisplayNewScore();
    }

    public int GetLastScoredPlayer()
    {
        return lastScoredPlayer;
    }

    private void DisplayNewScore()
    {
        player1ScoreText.text = currentScore.x.ToString();
        player2ScoreText.text = currentScore.y.ToString();
    }

    private void HandleGameOver()
    {
        if(currentScore.x >= maxScore || currentScore.y >= maxScore)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

    public void IncreaseScore(int playerNumber)
    {   
        if(playerNumber == 2)
            CurrentScore = new Vector2(CurrentScore.x + 1, currentScore.y);
        else 
            CurrentScore = new Vector2(CurrentScore.x, currentScore.y + 1);
    }

    public void ResetScore()
    {
        CurrentScore = new Vector2(0f, 0f);
    }
}   
