using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeen : MonoBehaviour
{
    private bool enemySeen;

    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            enemySeen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            enemySeen = false;
        }
    }

    public bool IsSeen()
    {
        return enemySeen;
    }
}
