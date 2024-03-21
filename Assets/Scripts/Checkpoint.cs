using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Checkpointer checkpointer;

    void Start()
    {
        checkpointer = GameObject.FindGameObjectWithTag("Checkpointer").GetComponent<Checkpointer>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            checkpointer.lastCheckpointPosition = transform.position;
        }
    }
}
