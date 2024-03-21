using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRangeChecker : MonoBehaviour
{
    private bool enemyInRange;

    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            enemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            enemyInRange = false;
        }
    }

    public bool IsInRange()
    {
        return enemyInRange;
    }
}
