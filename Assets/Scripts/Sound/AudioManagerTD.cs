using System;
using UnityEngine;

public class AudioManagerTD : MonoBehaviour
{
    public static AudioManagerTD Instance;

    [Header("Audio Sources")] 
    [SerializeField] private AudioSource sfxAudioSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip gunshotSound;
    [SerializeField] private AudioClip enemyDeathSound;
    
    private void Awake()
    {
        Instance = this;
    }

    public void PlayGunshot()
    {
        sfxAudioSource.PlayOneShot(gunshotSound);
    }

    public void PlayEnemyDeath()
    {
        sfxAudioSource.PlayOneShot(enemyDeathSound);
    }
}
