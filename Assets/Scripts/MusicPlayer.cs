using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        SetUpSingelton(); // Ensure only one instance of the music player exists
    }

    private void SetUpSingelton()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Keep this music player across scenes
        }
    }
}
