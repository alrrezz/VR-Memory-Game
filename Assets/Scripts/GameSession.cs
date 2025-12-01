using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System; // Required for Action and DateTime
using TMPro; // Required for TextMeshProUGUI (if still used elsewhere for example for score)

public class GameSession : MonoBehaviour
{
    [Header("Score & Lives")]
    [SerializeField] private int score = 0;
    [SerializeField] private int lives = 3;

    [Header("UI References")]
    [SerializeField] private Image[] heartImages; // UI Images for lives

    // Time tracking variables
    private float startTime;
    private float elapsedTime; // Total time player was active in the game

    // References to UI update scripts
    private LevelManager levelManager;
    private TimeTextUI timeTextUI;   // Reference to TimeTextUI
    private DataLogger dataLogger;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        timeTextUI = FindObjectOfType<TimeTextUI>(); // Get reference to TimeTextUI
        dataLogger = GetComponent<DataLogger>(); //Get refrence to DataLogger for save data in txt


        startTime = Time.time;
        elapsedTime = 0f;
    }

    private void Update()
    {
        // Update elapsed time only if the player still has lives
        // This ensures the timer stops when the game is over
        if (lives > 0)
        {
            elapsedTime = Time.time - startTime;
            // Update the timer UI through TimeTextUI
            if (timeTextUI != null)
            {
                timeTextUI.SetTimeDisplayText(elapsedTime);
            }
        }
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() => score;

    public void PlusScore(int value)
    {
        score += value;
    }

    public void LoseLife()
    {
        if (lives <= 0) return;

        lives--;
        // Update UI for lives
        if (heartImages != null && lives < heartImages.Length)
        {
            heartImages[lives].enabled = false;
        }

        if (lives == 0)
        {
            HandleGameOver();
        }
    }

    public int GetLives() 
    { 
        return lives; 
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    // This method is called to reset the game state
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    // Handles actions when the game is over
    private void HandleGameOver()
    {
        // Save Data in txt
        dataLogger.LogGameData(score, elapsedTime);
        // Load the Game Over Menu scene
        levelManager.LoadGameOverMenu();
    }
}