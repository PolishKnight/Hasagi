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
            DontDestroyOnLoad(instance);//Zachowanie informacji z checkpointera po ponownym za³¹dowaniu sceny
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
