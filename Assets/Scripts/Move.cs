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
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private GroundChecker wallChecker;
    private Vector3 input;
    private Jump jump;
    private PlayerDeath playerDeath;
    private AudioMenager audioMenager;

    private void Awake()
    {
        jump = gameObject.GetComponent<Jump>();
        playerDeath = gameObject.GetComponent<PlayerDeath>();
        audioMenager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMenager>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        if(!groundChecker.IsGrounded() && wallChecker.IsGrounded())
        {
            input = new Vector3(0, 0, 0);
        }
        else
        {
            input = new Vector3(inputX, 0, 0);
        }

        if (inputX < 0 && !playerDeath.isPlayerDead() && !audioMenager.IsTalking())
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (inputX > 0 && !playerDeath.isPlayerDead() && !audioMenager.IsTalking())
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (jump.IsJumping())//odegranie animacji skoku jeœli gracz skacze
        {
            animator.Play("Player Jump");
        }
        else if (rigidbody.velocity.y < -1)//odegranie animacji opadania jeœli gracz spada
        {
            animator.Play("Player Jump");
            animator.SetFloat("Phase", 4);
        }
        else if (inputX != 0 && !playerDeath.isPlayerDead() && !audioMenager.IsTalking())//odegranie animacji ruchu jeœli gracz siê porusza
        {
            animator.Play("Player Move");
        }
        else if(!playerDeath.isPlayerDead())//odegranie animacji stania
        {
            animator.Play("Player Stand");
        }
    }

    private void FixedUpdate()
    {
        if (!playerDeath.isPlayerDead() && !audioMenager.IsTalking())
        {
            Vector3 move = input * moveSpeed * Time.fixedDeltaTime;
            rigidbody.velocity = new Vector2(move.x, rigidbody.velocity.y); 
        }
        else//zatrzymanie gracza jeœli nie ¿yje
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
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
