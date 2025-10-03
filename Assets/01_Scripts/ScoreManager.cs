using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI TMP")]
    public TMP_Text player1Text; // izquierda
    public TMP_Text player2Text; // derecha

    [Header("Score")]
    public int player1Score = 0;
    public int player2Score = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddPointLeftPlayer()
    {
        player1Score++;
        UpdateUI();
    }

    public void AddPointRightPlayer()
    {
        player2Score++;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (player1Text) player1Text.text = player1Score.ToString();
        if (player2Text) player2Text.text = player2Score.ToString();
    }

    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateUI();
    }
}
