using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManagement : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject[] allObjects; // All available objects in the pool
    [SerializeField] private GameObject[] selectedTargets; // Selected target objects
    [SerializeField] private GameObject[] mixedObjects; // Mixed objects (target + non-target)

    public GameObject[] SelectedTargets => selectedTargets;
    public GameObject[] MixedObjects => mixedObjects;

    // Setup targets and mixed objects for a stage
    public void SetupObjects(int numberOfTargets, int totalObjectsToShow, int minTargetCountInMixed)
    {
        selectedTargets = GenerateTargets(numberOfTargets);
        mixedObjects = GenerateMixedObjectsWithMinTargets(selectedTargets, totalObjectsToShow, minTargetCountInMixed);
    }

    // Randomly select a number of targets
    private GameObject[] GenerateTargets(int count)
    {
        GameObject[] shuffled = ShuffleArray(allObjects);
        GameObject[] targets = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            targets[i] = shuffled[i];
        }

        return targets;
    }

    // Mix targets with other objects while ensuring a minimum number of targets
    private GameObject[] GenerateMixedObjectsWithMinTargets(GameObject[] targets, int totalCount, int minTargetCount)
    {
        List<GameObject> mixedList = new List<GameObject>();

        // Ensure at least minTargetCount target objects are included
        for (int i = 0; i < minTargetCount; i++)
        {
            GameObject randomTarget = targets[Random.Range(0, targets.Length)];
            mixedList.Add(randomTarget);
        }

        // Fill the rest with random objects
        while (mixedList.Count < totalCount)
        {
            GameObject candidate = allObjects[Random.Range(0, allObjects.Length)];
            mixedList.Add(candidate);
        }

        return ShuffleArray(mixedList.ToArray());
    }

    // Shuffle an array of objects
    private GameObject[] ShuffleArray(GameObject[] array)
    {
        GameObject[] shuffled = (GameObject[])array.Clone();

        for (int i = 0; i < shuffled.Length; i++)
        {
            int rnd = Random.Range(i, shuffled.Length);
            GameObject temp = shuffled[i];
            shuffled[i] = shuffled[rnd];
            shuffled[rnd] = temp;
        }

        return shuffled;
    }
}
