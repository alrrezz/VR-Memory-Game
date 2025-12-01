using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles playing sound effects for different events in the game
public class SFXPlayer : MonoBehaviour
{
    // Sound clips and their respective volume levels for different events
    [SerializeField] AudioClip correctAnswerSound;
    [Range(0, 1)][SerializeField] float correctAnswerSoundVolume = 0.5f;

    [SerializeField] AudioClip wrongAnswerSound;
    [Range(0, 1)][SerializeField] float wrongAnswerSoundVolume = 0.5f;

    [SerializeField] AudioClip targetNumberSound;
    [Range(0, 1)][SerializeField] float targetSoundVolume = 0.5f;

    // Plays the sound when the player selects a correct target
    public void PlayCorrectSFX()
    {
        AudioSource.PlayClipAtPoint(correctAnswerSound, Camera.main.transform.position, correctAnswerSoundVolume);
    }

    // Plays the sound when the player selects a wrong object
    public void PlayWrongSFX()
    {
        AudioSource.PlayClipAtPoint(wrongAnswerSound, Camera.main.transform.position, wrongAnswerSoundVolume);
    }

    // Plays the sound when the target object changes
    public void PlayTargetChangedSFX()
    {
        AudioSource.PlayClipAtPoint(targetNumberSound, Camera.main.transform.position, targetSoundVolume);
    }
}
