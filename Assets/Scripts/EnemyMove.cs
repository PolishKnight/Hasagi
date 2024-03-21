using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer playerGraphics;
    [SerializeField] private EnemySeen enemySeenLeft;
    [SerializeField] private BoxCollider2D visionLeft;
    [SerializeField] private EnemySeen enemySeenRight;
    [SerializeField] private BoxCollider2D visionRight;

    [SerializeField] private EnemyInRangeChecker enemyInRangeChecker;
    private Vector3 direction;

    private void Update()
    {
        if (enemySeenLeft.IsSeen())
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 180, 0);
            direction = new Vector3(-1, 0, 0);
            visionLeft.offset = new Vector2(4, 0);
            visionRight.offset = new Vector2(-4, 0);
        }
        if (enemySeenRight.IsSeen())
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = new Vector3(1, 0, 0);
            visionLeft.offset = new Vector2(-4, 0);
            visionRight.offset = new Vector2(4, 0);
        }
    }

    private void FixedUpdate()
    {
        if (!enemyInRangeChecker.IsInRange()&& !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead())
        {
            Vector3 move = direction * moveSpeed * Time.fixedDeltaTime;
            rigidbody.velocity = new Vector2(move.x, rigidbody.velocity.y);
        }
    }
}
