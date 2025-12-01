using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField][Range(1, 15)] private float speed = 2.0f; // Speed of forward movement
    [SerializeField] private Vector3 direction = Vector3.back; // Direction to move the object
    public bool canMove = true; // Whether the object is allowed to move

    void Update()
    {
        if (!canMove) { return; }

        // Move the object in the given direction at the specified speed
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
