using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private Ghost ghost;
    [SerializeField] private bool isGhostMoving;
    [SerializeField] private int ghostDataIndex;

    [SerializeField] private float speed;
    private float step;
    [SerializeField] private float distanceError;

    public GhostMovement(Ghost ghost)
    {
        this.ghost = ghost;
    }


    public Ghost Ghost
    {
        get { return ghost; }
        set { ghost = value; }
    }

    //____________________________________________


    // Use this for initialization
    void Start()
    {
        isGhostMoving = false;
        ghostDataIndex = 1;
        speed = 6f;
        distanceError = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGhostMoving && ghostDataIndex < ghost.GhostDataList.Count)
        {
            //moveGhost

            step = speed * Time.deltaTime;
            Vector3 targetPosition = new Vector3(ghost.getPositionVector(ghostDataIndex).x,
                ghost.getPositionVector(ghostDataIndex).y,
                ghost.getPositionVector(ghostDataIndex).z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

//            transform.eulerAngles = new Vector3(ghost.getRotationVector(ghostDataIndex).x,
//                ghost.getRotationVector(ghostDataIndex).y, ghost.getRotationVector(ghostDataIndex).z);
            Debug.Log("Vector3.Distance(transform.position, targetPosition): " +
                      Vector3.Distance(transform.position, targetPosition));
            if (Vector3.Distance(transform.position, targetPosition) < distanceError)
            {
                //TODO: aller d'un point à un autre en 1" et attendre 1" si on ne bouge pas
                ghostDataIndex++;
            }
        }
    }
}