using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float maxflayingtime;
    [SerializeField] private GroundChecker groundChecker;
    float flayingtime = 0;
    void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }
    private void Update()
    {
        if (!groundChecker.IsGrounded())
        {
            rigidbody.gravityScale = 2;
        }
        else
        {
            rigidbody.gravityScale = 0;
            rigidbody.velocity = new Vector2(0,0);
            rigidbody.velocity = transform.right * speed;
        }

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
