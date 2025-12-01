using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShredder : MonoBehaviour
{
    // Destroy any object that enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
