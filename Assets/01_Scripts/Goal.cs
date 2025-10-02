using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftGoal; // marcar en el inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Ball ball = other.GetComponent<Ball>();
            if (ball != null)
            {
                ball.ResetBall();
            }

            Debug.Log(isLeftGoal ? "Gol del jugador derecho" : "Gol del jugador izquierdo");
        }
    }
}