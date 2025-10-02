using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    public TextMeshProUGUI textPlayer1;
    public TextMeshProUGUI textPlayer2;
    public TextMeshProUGUI textHighScore; // opcional: muestra high score en HUD

    private int highScore = 0;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    public void AddPoint(int player)
    {
        if (player == 1) scorePlayer1++;
        else if (player == 2) scorePlayer2++;

        UpdateHighScoreIfNeeded();
        UpdateUI();

        // opcional: comprobar condición de Game Over (ejemplo: primer a 10)
        int target = 10;
        if (scorePlayer1 >= target || scorePlayer2 >= target)
        {
            // Guardar highscore y cambiar a escena GameOver
            SaveHighScore();
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateHighScoreIfNeeded()
    {
        int top = Mathf.Max(scorePlayer1, scorePlayer2);
        if (top > highScore)
        {
            highScore = top;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    void UpdateUI()
    {
        if (textPlayer1 != null) textPlayer1.text = scorePlayer1.ToString();
        if (textPlayer2 != null) textPlayer2.text = scorePlayer2.ToString();
        if (textHighScore != null) textHighScore.text = "High: " + highScore.ToString();
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public void ResetScores()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        UpdateUI();
    }
}