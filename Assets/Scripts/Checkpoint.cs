using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Checkpointer checkpointer;
    private Animator animator;
    private float timer = 0;

    void Start()
    {
        checkpointer = GameObject.FindGameObjectWithTag("Checkpointer").GetComponent<Checkpointer>();
        animator = gameObject.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            checkpointer.lastCheckpointPosition = transform.position;//przekazanie checkpointerowi o tym ¿e gracz go dotkn¹³
            animator.Play("CheckingCheckpoint");
            timer = 0.4f;
        }
    }
    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0 ) 
            {
                animator.Play("Checkpoint");
            }
        }
    }
}
