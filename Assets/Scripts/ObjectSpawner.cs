using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    [System.Serializable]
    public class StageSetting
    {
        public int numberOfTargets; // Number of targets to be shown
        public int totalObjectsToShow; // Total number of mixed objects
        public int minTargetCountInMixed; // Minimum number of targets among the mixed
    }

    [Header("Stages")]
    [SerializeField] private List<StageSetting> stages; // List of stage configurations

    [Header("Spawn Settings")]
    [SerializeField] private Transform spawnPoint; // Position where objects are spawned
    [SerializeField] private float spawnDelay = 0.5f; // Delay between spawns
    [SerializeField] private float waitBeforeNextStage = 2f; // Delay before proceeding to next stage
    [SerializeField] private float showingTargetsTime = 6f; //time of showing targets

    private ObjectManagement objectManagement;
    private SFXPlayer sFXPlayer;
    private int currentStage = 0;

    private void Start()
    {
        objectManagement = GetComponent<ObjectManagement>();
        sFXPlayer = GetComponent<SFXPlayer>();

        StartCoroutine(StageLoop());
    }

    // Main stage loop
    private IEnumerator StageLoop()
    {
        while (true)
        {
            StageSetting setting;

            // If we run out of stages, repeat the last one
            if (currentStage < stages.Count)
                setting = stages[currentStage];
            else
                setting = stages[stages.Count - 1];

            // Setup the objects for this stage
            objectManagement.SetupObjects(setting.numberOfTargets, setting.totalObjectsToShow, setting.minTargetCountInMixed);

            // Show targets, then destroy them
            yield return StartCoroutine(SpawnTargetObjects(objectManagement.SelectedTargets));

            // Show mixed objects for selection
            yield return StartCoroutine(SpawnMixedObjects(objectManagement.MixedObjects));

            // Proceed to next stage if available
            if (currentStage < stages.Count - 1)
                currentStage++;

            yield return new WaitForSeconds(waitBeforeNextStage);
        }
    }

    // Show target objects in a row, then remove them
    private IEnumerator SpawnTargetObjects(GameObject[] targets)
    {
        float spacing = 1.5f;
        int count = targets.Length;

        for (int i = 0; i < count; i++)
        {
            float xOffset = (i - (count - 1) / 2f) * spacing; //centered
            Vector3 spawnPos = spawnPoint.position + new Vector3(xOffset, 0f, 0f);

            GameObject instance = Instantiate(targets[i], spawnPos, targets[i].transform.rotation);
            instance.tag = "Target";
            instance.GetComponent<MoveForward>().canMove = false;

            sFXPlayer.PlayTargetChangedSFX();
        }

        yield return new WaitForSeconds(showingTargetsTime);

        // Remove all shown target objects
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(obj);
        }

        // Wait until all are destroyed
        while (GameObject.FindGameObjectsWithTag("Target").Length > 0)
        {
            yield return null;
        }
    }

    // Show the mixed objects (targets and distractors)
    private IEnumerator SpawnMixedObjects(GameObject[] mixed)
    {
        foreach (GameObject obj in mixed)
        {
            GameObject instance = Instantiate(obj, spawnPoint.position, obj.transform.rotation);

            if (System.Array.Exists(objectManagement.SelectedTargets, t => t.name == obj.name))
                instance.tag = "Target";
            else
                instance.tag = "Mixed";

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
