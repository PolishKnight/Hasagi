using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpPower = 15f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeOfJumping = 0.15f;
    [SerializeField] private float timeOfFalling = 0.2f;
    private bool isJumping = false;
    private float JumpPhase = 0;
    private float timer = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.IsGrounded() && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead() && !GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMenager>().IsTalking())
        {
            rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            isJumping = true;
            animator.Play("Player Jump");//zmienienie animacji na animacje skoku
            JumpPhase = 1;
            animator.SetFloat("Phase", JumpPhase);//skok(ustwienie parametru)
        }
        if (!groundChecker.IsGrounded())
        {
            rigidbody.freezeRotation = true;
        }
        else
        {
            rigidbody.freezeRotation = false;
        }
    }
    //zmienianie animaji przy poszczegulnych fazach skoku
    private void FixedUpdate()
    {
        if (JumpPhase == 1 && timer >= timeOfJumping)
        {
            timer = 0;
            JumpPhase = 2;
            animator.SetFloat("Phase", JumpPhase);//wznoszenie siê
        }
        if (JumpPhase == 2 && rigidbody.velocity.y < 0)
        {
            JumpPhase = 3;
            animator.SetFloat("Phase", JumpPhase);//zmiana z wznoszenia na opadanie
        }
        if (JumpPhase == 3 && timer >= timeOfJumping)
        {
            timer = 0;
            JumpPhase = 4;
            animator.SetFloat("Phase", JumpPhase);//opadanie
        }
        if (JumpPhase == 4 && groundChecker.IsGrounded())
        {
            JumpPhase = 0;
            isJumping = false;
        }
        if (isJumping && JumpPhase == 1 || JumpPhase == 3)
        {
            timer += Time.deltaTime;
        }
    }
    public bool IsJumping()
    {
        return isJumping;
    }
}

