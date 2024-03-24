using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioMenager : MonoBehaviour
{
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioSource teemoAudioSource;
    //pliki dŸwiêkowe
    [SerializeField] private AudioClip playerDearth;
    [SerializeField] private AudioClip aserio;
    [SerializeField] private AudioClip hasagi;
    [SerializeField] private AudioClip teemo1;
    [SerializeField] private AudioClip yasuo1;
    [SerializeField] private AudioClip teemo2;
    private float timer = 0;
    private bool isTalking = false;
    private int numberOfDialog = 1;
    public void PlayerDeathSound()
    {
        playerAudioSource.PlayOneShot(playerDearth);
    }
    public void TornadoSound()
    {
        System.Random rnd = new System.Random();
        int sound = rnd.Next(1, 3);
        if(sound == 1)
        {
            playerAudioSource.PlayOneShot(hasagi);
        }
        else
        {
            playerAudioSource.PlayOneShot(aserio);
        }
    }
    public void Dialog()
    {
        isTalking = true;
        numberOfDialog = 1;
    }
    private void Update()
    {
        if (isTalking)
        {
            timer+= Time.deltaTime;
            if(numberOfDialog == 1)
            {
                teemoAudioSource.PlayOneShot(teemo1);
                numberOfDialog = 2;
            }
            else if(numberOfDialog == 2 && timer >= 5)
            {
                playerAudioSource.PlayOneShot(yasuo1);
                numberOfDialog = 3;
            }
            else if (numberOfDialog == 3 && timer >= 8)
            {
                teemoAudioSource.PlayOneShot(teemo2);
                numberOfDialog = 0;
            }
            if(timer >= 10)
            {
                isTalking = false;
            }
        }
    }
    public bool IsTalking()
    {
        return isTalking;
    }
}
