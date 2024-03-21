using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private string groundTag = "Ground";
    [SerializeField] private string enemyTag = "Enemy";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            if (collision.gameObject.TryGetComponent<EnemyDearth>(out EnemyDearth dearth))
            {
                dearth.tornadoDamage();
            }
        }
        /*else if (collision.CompareTag(groundTag))
        {
            Destroy(gameObject);
        }*/
    }

}
