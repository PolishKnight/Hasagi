using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBulletMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private string groundTag = "Ground";
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float maxflayingtime;
    float flayingtime = 0;
    private PlayerDeath Killer;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Killer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();
        rigidbody.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(groundTag) || collision.CompareTag(playerTag))
        {
            Killer.damage(2);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(flayingtime < maxflayingtime)
        {
            flayingtime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
