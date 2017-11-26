using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGameOver : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip ghostMetAudioClip;


    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = ghostMetAudioClip;
    }


    #region OnTrigger

    private void OnTriggerEnter(Collider col)
    {
        if (!GameController.IsLevelCompleted && col.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision player-ghost detected");

            audioSource.Play();
            GameController.IsGameOver = true;
        }
    }

    #endregion
}