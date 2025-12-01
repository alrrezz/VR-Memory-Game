using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the visual effects (VFX) system for correct and incorrect actions
public class VFXSystem : MonoBehaviour
{
    // Configurable parameters
    [SerializeField] GameObject correctExplosionParticelPrefab; // Prefab for correct selection explosion effect
    [SerializeField] GameObject wrongExplosionParticelPrefab;   // Prefab for wrong selection explosion effect
    [SerializeField] float durationOfExplosion = 1f;            // Duration before destroying the VFX object

    // Spawns the correct answer explosion VFX at the specified position
    public void CorrectExplosionVFX(Vector3 position)
    {
        var explosionVFX = Instantiate(
            correctExplosionParticelPrefab,   // The correct explosion prefab
            position,                         // Where to spawn the explosion
            Quaternion.identity               // Default rotation
        );

        // Destroy the explosion effect after the set duration
        Destroy(explosionVFX, durationOfExplosion);
    }

    // Spawns the wrong answer explosion VFX at the specified position
    public void WrongExplosionVFX(Vector3 position)
    {
        var explosionVFX = Instantiate(
            wrongExplosionParticelPrefab,    // The wrong explosion prefab
            position,                        // Where to spawn the explosion
            Quaternion.identity              // Default rotation
        );

        // Destroy the explosion effect after the set duration
        Destroy(explosionVFX, durationOfExplosion);
    }
}
