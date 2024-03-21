using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform shootingPoing;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float Firerate;
    [SerializeField] private EnemyInRangeChecker enemyInRangeChecker;
    [SerializeField] private Animator animator;
    string currentAnimation = "Range Enemy Standing";
    float cooldown = 0;
    bool canshoot = true;
    void Update()
    {
        if (cooldown == 0 && enemyInRangeChecker.IsInRange() && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead())
        {
            cooldown = Firerate;
            currentAnimation = "Range Enemy Shooting";
            animator.Play(currentAnimation);
        }
        if (cooldown <= 0.43 && cooldown > 0 && canshoot == true)
        {
            Instantiate(bullet, shootingPoing.position, transform.rotation);
            canshoot = false;
        }
        if (cooldown <= 0.14 && cooldown > 0 && currentAnimation == "Range Enemy Shooting")
        {
            currentAnimation = "Range Enemy Standing";
            animator.Play(currentAnimation);
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0f)
            {
                cooldown = 0f;
                canshoot = true;
            }
        }
    }
}
