using UnityEngine;
using System.IO; // Required for file operations
using System;   // Required for DateTime

public class DataLogger : MonoBehaviour
{
    private string logFileName = "GameResults.txt"; // Name of the log file
    private string logFilePath; // Full path to the log file

    private void Awake()
    {
        // Set the path to the log file.
        // Application.persistentDataPath is a good place for saving data on most platforms.
        // On PC: C:\Users\<username>\AppData\LocalLow\<Company>\<Product>\
        logFilePath = Path.Combine(Application.persistentDataPath, logFileName);

        Debug.Log("Data Log File Path: " + logFilePath);

        // Ensure the log file exists and write header if it's a new file
        if (!File.Exists(logFilePath))
        {
            using (StreamWriter sw = File.CreateText(logFilePath))
            {
                sw.WriteLine("Timestamp,Score,Time_Elapsed_Seconds");
            }
        }
    }

    public void LogGameData(int score, float elapsedTime)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Get current timestamp
        string formattedElapsedTime = elapsedTime.ToString("F2"); //Format elapsed time to two decimal places
                                                                  //F2 for 2 decimal places
        string logEntry = $"{timestamp},{score},{formattedElapsedTime}"; // Create the log entry string

        // Append the log entry to the file
        try
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine(logEntry);
            }
            Debug.Log($"Game data logged: {logEntry}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to log file: {e.Message}");
        }
    }
}