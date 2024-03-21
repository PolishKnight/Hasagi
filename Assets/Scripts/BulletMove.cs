using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private string groundTag = "Ground";
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private float maxflayingtime;
    float flayingtime = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(groundTag) || collision.CompareTag(enemyTag))
        {
            if (collision.gameObject.TryGetComponent<EnemyDearth>(out EnemyDearth dearth))
            {
                dearth.damage();
            }
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (flayingtime < maxflayingtime)
        {
            flayingtime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
