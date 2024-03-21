using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointer : MonoBehaviour
{
    private static Checkpointer instance;
    public Vector2 lastCheckpointPosition;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
