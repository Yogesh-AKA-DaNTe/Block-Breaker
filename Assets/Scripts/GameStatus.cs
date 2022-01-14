using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    // Variables related to the current status of game
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] Text scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    void Awake()
    {
        // Singleton Pattern for GameStatus
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Sets current score to ScoreText
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        // Maintains given Game Speed
        Time.timeScale = gameSpeed;
    }

    // Function to add score when block is destroyed
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    // Function to reset the game
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    // Function to check if auto play is enabled or not
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
