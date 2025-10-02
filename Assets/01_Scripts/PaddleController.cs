using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleController : MonoBehaviour
{
    [Header("Controles")]
    public KeyCode upKey = KeyCode.W;      // Para el Player 1: W
    public KeyCode downKey = KeyCode.S;    // Para el Player 1: S
                                           // Para el Player 2: UpArrow / DownArrow

    [Header("Movimiento")]
    public float speed = 10f;      // Velocidad de la paleta
    public float limitY = 4.5f;    // Límite vertical (ajústalo a tu escena)

    private Rigidbody2D rb;
    private float input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;        // No rotación
        // En el Inspector puedes dejarlo Dynamic o Kinematic. Con MovePosition funciona en ambos.
    }

    void Update()
    {
        // Lee las teclas (1, 0, -1)
        input = (Input.GetKey(upKey) ? 1f : 0f) + (Input.GetKey(downKey) ? -1f : 0f);
    }

    void FixedUpdate()
    {
        // Movimiento suave e independiente del framerate
        Vector2 next = rb.position + Vector2.up * input * speed * Time.fixedDeltaTime;

        // Limitar dentro del campo
        next.y = Mathf.Clamp(next.y, -limitY, limitY);

        rb.MovePosition(next);
    }
}
