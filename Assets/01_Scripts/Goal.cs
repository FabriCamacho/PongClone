using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftGoal; // Si es el arco izquierdo

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;

        Ball ball = other.GetComponent<Ball>();
        if (ball != null) ball.ResetBall();

        // Si la pelota entra al arco izquierdo, anota el jugador derecho, y viceversa
        if (ScoreManager.Instance != null)
        {
            if (isLeftGoal) ScoreManager.Instance.AddPointRightPlayer();
            else ScoreManager.Instance.AddPointLeftPlayer();
        }
    }
}
