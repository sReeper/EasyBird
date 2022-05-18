using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager audioManager;

    // Clips
    public AudioClip jumpClip;
    public AudioClip deathClip;
    public AudioClip scoreClip;
    public AudioClip buttonClickClip;

    // Sources
    AudioSource playerSource;

    void Awake()
    {
        if (audioManager != null && audioManager != this)
        {
            Destroy(gameObject);
            return;
        }

        audioManager = this;
        DontDestroyOnLoad(gameObject);

        playerSource = gameObject.AddComponent<AudioSource>() as AudioSource;
    }

    public static void PlayJumpSound()
    {
        if (audioManager == null)
        {
            return;
        }

        audioManager.playerSource.clip = audioManager.jumpClip;
        audioManager.playerSource.Play();
    }

    public static void PlayDeathSound()
    {
        if (audioManager == null || GameManager.Instance.CurrentStatus != GameManager.Status.RUNNING)
        {
            return;
        }

        audioManager.playerSource.clip = audioManager.deathClip;
        audioManager.playerSource.Play();
    }

    public static void PlayScoreSound()
    {
        if (audioManager == null)
        {
            return;
        }

        audioManager.playerSource.clip = audioManager.scoreClip;
        audioManager.playerSource.Play();
    }

    public static void PlayButtonClickSound()
    {
        if (audioManager == null)
        {
            return;
        }

        audioManager.playerSource.clip = audioManager.buttonClickClip;
        audioManager.playerSource.Play();
    }

}
