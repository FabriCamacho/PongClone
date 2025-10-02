using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // M�todo para cargar la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadScene("Game"); // Nombre exacto de tu escena del juego
    }

    // M�todo para cerrar la aplicaci�n
    public void QuitGame()
    {
        Debug.Log("Cerrando juego..."); // Para pruebas dentro del editor
        Application.Quit(); // Esto s� cierra el juego en build
    }
}
