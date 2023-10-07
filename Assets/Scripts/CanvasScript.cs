using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public void StartGame()
    {
        // Load your game scene here
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        // Quit the application
       
    }
    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
