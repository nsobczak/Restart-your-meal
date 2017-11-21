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

//        gameController = .GetGameControllerInstance;
//        Debug.Log("GameController.GetGameControllerInstance: " +
//                  gameController);
    }

    void Update()
    {
//        Debug.Log("GameController.GetGameControllerInstance.CollectableFoodCount: " +
//                  gameController.CollectableFoodCount);

        textFoodCount.text = GameController.CollectableFoodCount.ToString();
    }
}