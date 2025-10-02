using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public float speedIncrease = 1f;
    private Rigidbody rb;
    private float fixedZ = -11.7514f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ |
                         RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationY;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        LaunchBall();
    }

    void LaunchBall()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);
        Vector3 direction = new Vector3(x, y, 0).normalized;
        rb.velocity = direction * speed;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(0, 0, fixedZ);
        rb.velocity = Vector3.zero;
        Invoke(nameof(LaunchBall), 1f);
        speed = 10f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Aumentar velocidad sin modificar la dirección de rebote
        rb.velocity *= 1 + (speedIncrease / rb.velocity.magnitude);
    }
}
