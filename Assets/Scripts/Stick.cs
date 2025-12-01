using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the player's "stick" or selecting object in VR.
// It detects collision with objects and determines whether the selected object was correct or not.
public class Stick : MonoBehaviour
{
    [SerializeField] private float objectDestroydelay = 0.3f;  // Delay before destroying the collided object
    [SerializeField] private int score = 26; // Score awarded for selecting the correct object

    private ScoreTextUI scoreUI;
    private SFXPlayer soundPlayer;
    private VFXSystem vfxSystem;
    private GameSession gameSession;

    // Initialize references to other components and systems
    private void Start()
    {
        scoreUI = GetComponent<ScoreTextUI>();
        soundPlayer = GetComponent<SFXPlayer>();
        vfxSystem = GetComponent<VFXSystem>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Called when another collider enters the trigger zone of the stick
    private void OnTriggerEnter(Collider other)
    {
        // Ignore collisions with objects that are not tagged as "Target" or "Mixed"
        if (!other.CompareTag("Target") && !other.CompareTag("Mixed")) return;

        // Check whether the object is one of the target objects
        bool isTarget = other.CompareTag("Target");

        if (isTarget)
        {
            // Correct selection
            soundPlayer.PlayCorrectSFX();
            scoreUI.AddScore(score);
            vfxSystem.CorrectExplosionVFX(other.transform.position);
        }
        else
        {
            // Wrong selection
            soundPlayer.PlayWrongSFX();
            vfxSystem.WrongExplosionVFX(other.transform.position);
            gameSession.LoseLife(); // Decrease player's life
        }

        // Destroy the selected object after a short delay
        Destroy(other.gameObject, objectDestroydelay);
    }
}
