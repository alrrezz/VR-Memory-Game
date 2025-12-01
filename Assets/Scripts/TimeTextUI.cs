using UnityEngine;
using TMPro;
using System; // Required for formatting TimeSpan

public class TimeTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component for displaying time
    private GameSession gameSession; // Reference to the GameSession script

    private void Start()
    {
        // Find and get a reference to the GameSession instance in the scene
        gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            // Initialize the timer display based on the current elapsed time from GameSession
            SetTimeDisplayText(gameSession.GetElapsedTime());
        }
        else
        {
            Debug.LogError("GameSession not found in the scene. TimeTextUI cannot initialize.");
        }
    }

    // Method to set the text display of the timer
    // This method will be called by GameSession's Update method
    public void SetTimeDisplayText(float timeInSeconds)
    {
        if (timerText != null)
        {
            // Format the time as minutes:seconds (e.g., 02:35)
            // Using TimeSpan for cleaner formatting
            TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);
            timerText.text = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
        }
    }
}