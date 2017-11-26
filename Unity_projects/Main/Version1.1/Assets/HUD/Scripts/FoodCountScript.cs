using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCountScript : MonoBehaviour
{
    #region Parameters

    private Text textFoodCount;

    private AudioSource audioSource;
    [SerializeField] private AudioClip oneMoreFoodAudioClip;
    private int foodCountScript_internFoodCount;

    #endregion

    
    //_________________________________________________
    
    private bool ShouldPlayAudioClip()
    {
        if (GameController.CollectableFoodCount > foodCountScript_internFoodCount)
        {
            foodCountScript_internFoodCount++;
            return true;
        }
        else
            return false;
    }

    
    //_________________________________________________

    void Start()
    {
        textFoodCount = GetComponent<Text>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = oneMoreFoodAudioClip;
        foodCountScript_internFoodCount = 0;
    }

    void Update()
    {
        textFoodCount.text = " " + GameController.CollectableFoodCount.ToString() + "/" +
                             GameController.MaxCollectableFood.ToString();
        if (ShouldPlayAudioClip())
            audioSource.Play();
    }
}