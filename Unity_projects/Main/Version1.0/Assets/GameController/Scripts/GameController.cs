using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private int menuSceneId = 0;
    
    private static GameController gameControllerInstance = null;
    private static int _max_Collectable_Food_Count_ = 5;
    private static int collectableFoodCount;
    private static bool isGameOver;

    private GameObject gameOverCanvas;


    //___________________________________________

    #region singleton

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

    #endregion

    #region Getter/Setter

    public static int CollectableFoodCount
    {
        get { return collectableFoodCount; }
        set { collectableFoodCount = value; }
    }

    public static int MaxCollectableFood
    {
        get { return _max_Collectable_Food_Count_; }
    }

    public static bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    #endregion


    //____________________________________________
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }


    void GameOver()
    {
        Debug.Log("game over");
        GhostGenerator.IsGameOver = true;
        gameOverCanvas.SetActive(true);
    }


    public void GameOverPanelButtonClicked()
    {
        Debug.Log("GameOverPanel button clicked");
        //TODO: open menu scene, destroy this scene and game object
        SceneManager.LoadScene(menuSceneId);
        Destroy(gameObject);
    }


    //____________________________________________
    void Start()
    {
        isGameOver = false;
        gameOverCanvas = transform.GetChild(0).gameObject;
        Debug.Log("gameOverCanvas: " + gameOverCanvas);
    }


    void Update()
    {
        if (isGameOver)
        {
            GameOver();
        }
    }
}