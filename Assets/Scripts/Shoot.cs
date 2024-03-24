using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootingPoing;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject tornado;
    [SerializeField] private Animator Ranimator;
    [SerializeField] private Animator Qanimator;
    [SerializeField] private float Firerate;
    [SerializeField] private float tornadoFirerate;
    AudioMenager audioMenager;
    float cooldown = 0;
    float tornadoCooldown = 0;
    private void Awake()
    {
        audioMenager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMenager>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && cooldown == 0 && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead() && !audioMenager.IsTalking())//dodanie pocisku jeœli gracz nacisk q i cooldown jest równy 0
        {
            Instantiate(bullet, shootingPoing.position, transform.rotation);
            cooldown = Firerate;
            Qanimator.Play("LoadingQ");//odegranie animacji ³adowania strza³u 
        }
        if (Input.GetKey(KeyCode.R) && tornadoCooldown == 0 && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>().isPlayerDead() && !audioMenager.IsTalking())//dodanie tornada jeœli gracz nacisk r i cooldown jest równy 0
        {
            Instantiate(tornado, shootingPoing.position, transform.rotation);
            tornadoCooldown = tornadoFirerate;
            audioMenager.TornadoSound();//odegranie dŸwiêku tornada
            Ranimator.Play("LoadingR");//odegranie animacji ³adowania tornada
        }
        if (cooldown > 0) 
        {
            cooldown -= Time.deltaTime;//zmniejszenie cooldownu strza³u jeœli jest wiêkszy od zera
            if (cooldown <= 0f)
            {
                cooldown = 0f;
                Qanimator.Play("Q");//odegranie animacji pokazuj¹cej ¿e strza³ jest gotowy
            }
        }
        if (tornadoCooldown > 0)//zmniejszenie cooldownu tornada jeœli jest wiêkszy od zera
        {
            tornadoCooldown -= Time.deltaTime;
            if (tornadoCooldown <= 0f)
            {
                tornadoCooldown = 0f;
                Ranimator.Play("R");//odegranie animacji pokazuj¹cej ¿e tornado jest gotowe 
            }
        }
    }
}
