using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public enum Status
    {
        GAME_OVER,
        RUNNING,
        PAUSED,
        START
    }

    private static GameManager _instance;

    public GameOverScreen gameOverScreen;
    public TextMeshProUGUI startText;

    public Status CurrentStatus { get; private set; }

    public static GameManager Instance { get { return _instance; } }
    public int Score { get; private set; }

    public int BestScore { get; private set; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        CurrentStatus = Status.START;

        PopulateStartText();
        

        BestScore = PlayerPrefs.GetInt("bestScore");
    }

    private void PopulateStartText()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            startText.text = "Touch to Start";
        }
        startText.gameObject.SetActive(true);
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void IncreaseScore()
    {
        Score++;
    }

    public void StartGame()
    {
        CurrentStatus = Status.RUNNING;
        Score = 0;
        startText.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        CurrentStatus = Status.GAME_OVER;
        if (Score > BestScore)
        {
            PlayerPrefs.SetInt("bestScore", Score);
            BestScore = Score;
        }
        gameOverScreen.GameOver(Score, BestScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartCoroutine(DelayStart());
        StartGame();
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
