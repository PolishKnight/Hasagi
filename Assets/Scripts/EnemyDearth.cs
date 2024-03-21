using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDearth : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private string bulletTag = "bullet";
    [SerializeField] private string spikeTag = "Spike";
    [SerializeField] private int maxHealth;
    [SerializeField] private float throwPower = 15f;
    [SerializeField] private SpriteRenderer healthBar;
    [SerializeField] private Sprite health2of3;
    [SerializeField] private Sprite health1of3;
    [SerializeField] private Sprite health1of2;

    private int health;
    private void Start()
    {
        health = maxHealth;
    }
    public void damage()
    {
        health--;
        if (maxHealth == 3 && health == 2)
        {
            healthBar.sprite = health2of3;
        }
        else if (maxHealth == 3 && health == 1)
        {
            healthBar.sprite = health1of3;
        }
        else if (maxHealth == 2 && health == 1)
        {
            healthBar.sprite = health1of2;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void tornadoDamage()
    {
        damage();
        rigidbody.AddForce(new Vector2(0, throwPower), ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(spikeTag))
        {
            Destroy(gameObject);
        }
    }
}
