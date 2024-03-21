using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioMenager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public AudioClip playerDearth;
    public AudioClip aserio;
    public AudioClip hasagi;
    public void PlayerDearthSound()
    {
        audioSource.PlayOneShot(playerDearth);
    }
    public void TornadoSound()
    {
        System.Random rnd = new System.Random();
        int sound = rnd.Next(1, 3);
        if(sound == 1)
        {
            audioSource.PlayOneShot(hasagi);
        }
        else
        {
            audioSource.PlayOneShot(aserio);
        }
    }
}
