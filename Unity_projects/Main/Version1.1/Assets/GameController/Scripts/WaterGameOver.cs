using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGameOver : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip splashInWaterAudioClip;


    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = splashInWaterAudioClip;
    }


    void OnCollisionEnter(Collision col)
    {
        if (!GameController.IsLevelCompleted && col.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision player-water detected");

            audioSource.Play();
            GameController.IsGameOver = true;
        }
    }
}