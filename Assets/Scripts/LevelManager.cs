using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float gameOverDelayInSeconds = 2.0f; // Delay before loading Game Over screen

    // Load the main start menu (scene index 0)
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Load the main game scene
    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");

        // If a GameSession already exists, reset its state for a fresh start
        if (FindObjectsOfType<GameSession>().Length > 0)
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
    }

    // Load the Game Over Menu with a delay
    public void LoadGameOverMenu()
    {
        StartCoroutine(WaitAndLoad());
    }

    // Coroutine to wait for a delay before showing Game Over screen
    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(gameOverDelayInSeconds);
        SceneManager.LoadScene("Game Over Menu");
    }

    // Load the credits scene
    public void LoadCredditMenu()
    {
        SceneManager.LoadScene("Creddit Menu");
    }

    // Exit the application (only works in built app)
    public void QuitGame()
    {
        Application.Quit();
    }

    // Load the next scene in build index order
    public void LoadNextLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene + 1);
    }
}
