using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI TMP")]
    public TMP_Text player1Text;
    public TMP_Text player2Text;
    public TMP_Text highScoreText; // texto para mostrar la mejor puntuación

    [Header("Score")]
    public int player1Score = 0;
    public int player2Score = 0;

    private int highScore = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;

        // Cargar high score guardado
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    public void AddPointLeftPlayer()
    {
        player1Score++;
        CheckHighScore(player1Score);
        UpdateUI();
    }

    public void AddPointRightPlayer()
    {
        player2Score++;
        CheckHighScore(player2Score);
        UpdateUI();
    }

    private void CheckHighScore(int currentScore)
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void UpdateUI()
    {
        if (player1Text) player1Text.text = player1Score.ToString();
        if (player2Text) player2Text.text = player2Score.ToString();
        if (highScoreText) highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateUI();
    }
}
