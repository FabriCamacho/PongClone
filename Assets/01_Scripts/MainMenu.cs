using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Método para cargar la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // Nombre exacto de tu escena del juego
    }

    // Método para cerrar la aplicación
    public void QuitGame()
    {
        Debug.Log("Cerrando juego..."); // Para pruebas dentro del editor
        Application.Quit(); // Esto sí cierra el juego en build
    }
}
