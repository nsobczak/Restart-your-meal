using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCountScript : MonoBehaviour
{
    private Text textFoodCount;
//    private GameController gameController;

    void Start()
    {
        textFoodCount = GetComponent<Text>();
    }

    void Update()
    {
        textFoodCount.text = " " + GameController.CollectableFoodCount.ToString() + "/" +
                             GameController.MaxCollectableFood.ToString();
    }
}