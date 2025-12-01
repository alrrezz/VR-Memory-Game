using UnityEngine;
using TMPro;

public class ScoreTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for displaying the score
    private GameSession gameSession; // Reference to the GameSession script

    private void Start()
    {
        // Find and get a reference to the GameSession instance in the scene
        gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            // Initialize the score display based on the current score from GameSession
            SetScoreText(gameSession.GetScore());
        }
        else
        {
            // Log an error if GameSession is not found, as it's a critical dependency
            Debug.LogError("GameSession not found in the scene. ScoreTextUI cannot initialize.");
        }
    }

    // Method to add score, moved from the original HandleScore script
    public void AddScore(int value)
    {
        if (gameSession != null)
        {
            gameSession.PlusScore(value); // Increase the score in GameSession
            SetScoreText(gameSession.GetScore()); // Update the UI text immediately
        }
        else
        {
            Debug.LogError("GameSession is null. Cannot add score.");
        }
    }

    // Method to set the text display of the score
    public void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}