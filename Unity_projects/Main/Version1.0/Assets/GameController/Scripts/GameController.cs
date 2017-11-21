using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController gameControllerInstance = null;

    [SerializeField] private int _max_Collectable_Food_Count_ = 5;
    private static int collectableFoodCount;


    //___________________________________________
    // === singleton ===
    private GameController()
    {
        collectableFoodCount = 0;
    }

    public static GameController GetGameControllerInstance
    {
        get
        {
            if (gameControllerInstance == null)
                gameControllerInstance = new GameController();
            return gameControllerInstance;
        }
    }

    public static int CollectableFoodCount
    {
        get { return collectableFoodCount; }
        set { collectableFoodCount = value; }
    }


    //____________________________________________
//    void Start()
//    {
//    _max_Collectable_Food_Count_ = GameObject.findGameObjectWithTag("Food").Count;
//    }


//    void Update()
//    {
//        Debug.Log("collectableFoodCount: " + collectableFoodCount);
//        if (GameController.collectableFoodCount >= _max_Collectable_Food_Count_)
//        {
            // isLevelCompleted = true   
//        }
//    }
}