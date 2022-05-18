using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerReferences : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public TextMeshProUGUI startText;

    void Start()
    {
        GameManager.Instance.gameOverScreen = gameOverScreen;
        GameManager.Instance.startText = startText;
    }
}
