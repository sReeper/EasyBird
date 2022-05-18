using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    public void GameOver(int score, int bestScore)
    {
        gameObject.SetActive(true);
        finalScoreText.text = "Score: " + score.ToString();
        bestScoreText.text = "Best Score: " + bestScore.ToString();
        scoreText.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }

    public void QuitGame()
    {
        GameManager.Instance.ExitGame();
    }
 
}
