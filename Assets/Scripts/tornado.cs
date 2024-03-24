using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float maxflayingtime;
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private GroundChecker wallChecker;
    [SerializeField] private string groundTag = "Ground";
    [SerializeField] private string enemyTag = "Enemy";
    float flayingtime = 0;
    void Start()
    {
        rigidbody.velocity = transform.right * speed;//dodanie ruchu tornada
    }
    private void Update()
    {
        if (!groundChecker.IsGrounded())//dodanie grawitacji jeœli tornado nie dotyka ziemi
        {
            rigidbody.gravityScale = 2;
        }
        else// usuniêcie grawitacji jêsli tornado nie dotyka ziemi
        {
            rigidbody.gravityScale = 0;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.velocity = transform.right * speed;
        }

        if (flayingtime < maxflayingtime)
        {
            flayingtime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);//usuniêcie obiektu jeœli czas lotu jest wiêkszy od maksymalnego czasu loty
        }
        if (wallChecker.IsGrounded())
        {
            Destroy(gameObject);//usuniêcie obiekty jeœli dotknie œciany
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            if (!collision.gameObject.GetComponent<EnemyDearth>().isTornaded())
            {
                collision.gameObject.GetComponent<EnemyDearth>().tornadoDamage();//zadanie obra¿eñ i podrzucenie wroga
            }
        }
    }
}
