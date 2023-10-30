using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FootstepSounds : MonoBehaviour
{
    public float walkStepsCooldown = 1f;
    public float runStepsCooldown = 0.5f;
    public AudioClip leftFootSound;
    public AudioClip rightFootSound;
    private AudioSource audioSource;
    private float timer = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayFootstepSound()
    {
        if (Random.Range(0, 2) == 0)
        {
            audioSource.PlayOneShot(leftFootSound);
        }
        else
        {
            audioSource.PlayOneShot(rightFootSound);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime; 
    }

    // ¬ызывайте этот метод в своем скрипте движени€ персонажа в соответствующий момент
    // например, при каждом шаге персонажа
    public void PlayFootstep(bool isRunning)
    {
        switch(isRunning)
        {
            case true:
                if(timer >= runStepsCooldown)
                {
                    timer = 0f;
                    PlayFootstepSound();
                }
                break;

            case false:
                if (timer >= walkStepsCooldown)
                {
                    timer = 0f;
                    PlayFootstepSound();
                }
                break;
        }
    }
}
