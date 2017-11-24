using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPointController : MonoBehaviour
{
    /*TODO:
    - create ghostCount+1 spawning points
    - make player spawn on new spawning point
    */

    #region Parameters

    [SerializeField] private GameObject spawningPointPrefab;
    [SerializeField] private float _SPAWNING_POINT_OFFESET_ = 5f;
    [SerializeField] private int spawningPointCount; //may be useless if we create a new point each time we restart level
    private GameObject player;

    private GameObject currentSpawningPoint;

    #endregion


    //___________________________________

    #region singleton

    private static SpawningPointController spawningPointControllerInstance = null;

    private SpawningPointController()
    {
    }

    public static SpawningPointController GetGameControllerInstance
    {
        get
        {
            if (spawningPointControllerInstance == null)
                spawningPointControllerInstance = new SpawningPointController();
            return spawningPointControllerInstance;
        }
    }

    #endregion


    //___________________________________

    #region Methods

    private void AddSpawningPoint()
    {
        spawningPointCount++;
        Vector3 newSpawningPointPostion = new Vector3();
        Vector3 newSpawningPointRotation = new Vector3();
        currentSpawningPoint = Instantiate(spawningPointPrefab, newSpawningPointPostion,
            Quaternion.Euler(newSpawningPointRotation));

        currentSpawningPoint.GetComponent<MeshRenderer>().gameObject.SetActive(false); //make it invisible
    }


    private void SpawnPlayer()
    {
        player.transform.position = new Vector3(transform.position.x, transform.position.y,
            transform.position.z - _SPAWNING_POINT_OFFESET_);
    }

    #endregion


    //___________________________________

    void Start()
    {
        spawningPointCount = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("player: " + player);
        SpawnPlayer();
    }

//    void Update()
//    {
//    }
}