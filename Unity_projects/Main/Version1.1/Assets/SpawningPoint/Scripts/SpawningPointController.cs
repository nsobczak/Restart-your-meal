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
    [SerializeField] private float _SPAWNING_POINT_OFFSET_ = 6f;
    [SerializeField] private int _RADIUS_MIN_ = 30;
    [SerializeField] private int _RADIUS_MAX_ = 50;
    [SerializeField] private float _DISTANCE_MIN_BETWEEN_SPAWNING_POINTS_ = 4f;


    [SerializeField] private bool instantiateNewSpawningPoint;
    private List<Vector3> spawningPointPositions;

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

    //Compute position for new spawning point in spawningPointGenerator
    private Vector3 computeNewPosition()
    {
        int radius = Random.Range(_RADIUS_MIN_, _RADIUS_MAX_);
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector3 newPosition = new Vector3(transform.position.x + radius * Mathf.Cos(angle),
            transform.position.y + _SPAWNING_POINT_OFFSET_,
            transform.position.z + radius * Mathf.Sin(angle));
        return newPosition;
    }


    //check distance btween spawning points
    private bool isNewSpawningPointValid(Vector3 newSpawningPointPostion)
    {
        if (spawningPointPositions.Count > 0)
        {
            foreach (Vector3 spawningPoint in spawningPointPositions)
            {
                if (Vector3.Distance(newSpawningPointPostion, spawningPoint) < _DISTANCE_MIN_BETWEEN_SPAWNING_POINTS_)
                {
                    return false;
                }
            }
            return true;
        }
        else
            return true;
    }


    private void AddSpawningPoint()
    {
        Vector3 newSpawningPointPostion = computeNewPosition();

        while (!isNewSpawningPointValid(newSpawningPointPostion))
            newSpawningPointPostion = computeNewPosition();


        Debug.Log("newSpawningPointPostion: " + newSpawningPointPostion);
        currentSpawningPoint = Instantiate(spawningPointPrefab, newSpawningPointPostion,
            Quaternion.identity);
        currentSpawningPoint.transform.parent = transform;

        //add it to the list
        spawningPointPositions.Add(currentSpawningPoint.transform.position);
        //make it invisible
        currentSpawningPoint.GetComponent<MeshRenderer>().gameObject.SetActive(false); 
    }


    private void SpawnPlayer()
    {
        player.transform.position = new Vector3(currentSpawningPoint.transform.position.x,
            currentSpawningPoint.transform.position.y,
            currentSpawningPoint.transform.position.z);
    }

    #endregion


    //___________________________________

    void Start()
    {
        instantiateNewSpawningPoint = false;

        spawningPointPositions = new List<Vector3>();
        AddSpawningPoint();

        player = GameObject.FindGameObjectWithTag("Player");
        SpawnPlayer();
    }

    void Update()
    {
        if (instantiateNewSpawningPoint)
        {
            AddSpawningPoint();
            instantiateNewSpawningPoint = false;
        }
//        Debug.Log("Random.Range(_RADIUS_MIN_, _RADIUS_MAX_) = " + Random.Range(_RADIUS_MIN_, _RADIUS_MAX_));
//        Debug.Log("Random.Range(0, Mathf.PI) = " + Random.Range(0, Mathf.PI));
    }
}