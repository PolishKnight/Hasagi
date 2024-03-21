using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    private EnemyAtack AtackInformation;
    private PlayerDeath Killer;
    private bool atack =  false;

    private void Awake()
    {
        AtackInformation = transform.parent.gameObject.GetComponent<EnemyAtack>();
        Killer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag) && atack == true)
        {
            Killer.damage(3);
            atack = false;
        }
    }
    public void StartAtack()
    {
        atack = true;
    }
    public void StopAtack()
    {
        atack = false;
    }
}
