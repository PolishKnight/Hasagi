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
    [SerializeField] private EnemySeen Range;//tutaj przypisujemy range
    [SerializeField] private Animator animator;
    string currentAnimation = "Range Enemy Standing";
    float cooldown = 0;
    bool canshoot = true;
    void Update()
    {
        if (cooldown == 0 && Range.IsSeen() && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead() && !gameObject.GetComponent<EnemyDearth>().isDead())//zaczêcie animacji gdy gracz jest w zsiêgu
        {
            cooldown = Firerate;//dodanie cooldownu
            currentAnimation = "Range Enemy Shooting";
            animator.Play(currentAnimation);
        }
        if (cooldown <= 0.43 && cooldown > 0 && canshoot == true && !gameObject.GetComponent<EnemyDearth>().isDead())//wystrzelenie pocisku w takim momêcie by by³ zsynchronizowany z animacj¹
        {
            Instantiate(bullet, shootingPoing.position, transform.rotation);
            canshoot = false;
        }
        if (cooldown <= 0.14 && cooldown > 0 && currentAnimation == "Range Enemy Shooting" && !gameObject.GetComponent<EnemyDearth>().isDead())//zmiana animacji po skoñczeniu animacji
        {
            currentAnimation = "Range Enemy Standing";
            animator.Play(currentAnimation);
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;//dodanie czasu do cooldownu
            if (cooldown <= 0f)
            {
                cooldown = 0f;
                canshoot = true;
            }
        }
    }
}
