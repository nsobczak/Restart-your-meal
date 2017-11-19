using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController gameControllerInstance = null;

    [SerializeField] private int collectableFoodCount;


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

    public int CollectableFoodCount
    {
        get { return collectableFoodCount; }
        set { collectableFoodCount = value; }
    }


    //____________________________________________
//    void Start()
//    {
//    }


    void Update()
    {
        Debug.Log("collectableFoodCount: " + collectableFoodCount);
    }
}