using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer playerGraphics;
    [SerializeField] private Animator animator;

    private Vector3 input;
    private Jump jump;

    private void Awake()
    {
        jump = gameObject.GetComponent<Jump>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        input = new Vector3(inputX, 0, 0);

        if (inputX < 0)
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (inputX > 0)
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (jump.IsJumping())
        {
            animator.Play("Player Jump");
        }
        else if (rigidbody.velocity.y < -1)
        {
            animator.Play("Player Jump");
            animator.SetFloat("Phase", 4);
        }
        else if (inputX != 0 && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead())
        {
            animator.Play("Player Move");
        }
        else
        {
            animator.Play("Player Stand");
        }
    }

    private void FixedUpdate()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead())
        {
            Vector3 move = input * moveSpeed * Time.fixedDeltaTime;
            rigidbody.velocity = new Vector2(move.x, rigidbody.velocity.y); 
        }
    }
    public string GetDirection() 
    {
        if(playerGraphics.transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            return "left";
        }
        else
        {
            return "right";
        }
    }
}
