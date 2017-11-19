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

    private float timerBetweenPositions;

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
        timerBetweenPositions = GhostGenerator.GetGhostGeneratorInstance.TimerRecordGhostTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGhostMoving && ghostDataIndex < ghost.GhostDataList.Count)
        {
            //moveGhost
            timerBetweenPositions -= Time.deltaTime;

            step = speed * Time.deltaTime;
            Vector3 targetPosition = new Vector3(ghost.getPositionVector(ghostDataIndex).x,
                ghost.getPositionVector(ghostDataIndex).y,
                ghost.getPositionVector(ghostDataIndex).z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

//            transform.eulerAngles = new Vector3(ghost.getRotationVector(ghostDataIndex).x,
//                ghost.getRotationVector(ghostDataIndex).y, ghost.getRotationVector(ghostDataIndex).z);
//            Debug.Log("Vector3.Distance(transform.position, targetPosition): " +
//                      Vector3.Distance(transform.position, targetPosition));

            if (Vector3.Distance(transform.position, targetPosition) < distanceError &&
                timerBetweenPositions <= 0f)
            {
                //TODO: calculer la vitesse de déplacement, do function ?
                ghostDataIndex++;
                timerBetweenPositions = GhostGenerator.GetGhostGeneratorInstance.TimerRecordGhostTransform;
            }
        }
    }
}