using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private Checkpointer checkpointer;
    void Start()
    {
        checkpointer = GameObject.FindGameObjectWithTag("Checkpointer").GetComponent<Checkpointer>();
        transform.position = checkpointer.lastCheckpointPosition;//ustawienie pozycji gracza na ostatni checkpoint
    }
}
