using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private Ghost ghost;
    [SerializeField] private bool isGhostMoving;
    [SerializeField] private int ghostDataIndex;

    [SerializeField] private float speed;
    [SerializeField] private float distanceError;

    private float timerBetweenPositions;
    private float distanceToMove;
    private Vector3 targetPosition;
    private Vector3 newDir;

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

    private void computeTargetPosition()
    {
        targetPosition = new Vector3(ghost.getPositionVector(ghostDataIndex).x,
            ghost.getPositionVector(ghostDataIndex).y,
            ghost.getPositionVector(ghostDataIndex).z);
    }

    void Start()
    {
        isGhostMoving = false;

        distanceError = 0.01f;
        timerBetweenPositions = GhostGenerator.GetGhostGeneratorInstance.TimerRecordGhostTransform;

        ghostDataIndex = 1;

        computeTargetPosition();

        distanceToMove = Vector3.Distance(transform.position, targetPosition);
        speed = distanceToMove / GhostGenerator.GetGhostGeneratorInstance.TimerRecordGhostTransform;
    }


    void Update()
    {
        if (isGhostMoving && ghostDataIndex < ghost.GhostDataList.Count)
        {
            //moveGhost
            timerBetweenPositions -= Time.deltaTime;

            //translate
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            //rotate
            newDir = Vector3.RotateTowards(Vector3.up, targetPosition - transform.position,
                speed * Time.deltaTime, 0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
//            transform.rotation = Quaternion.FromToRotation(Vector3.up, targetPosition - transform.position);


            if (Vector3.Distance(transform.position, targetPosition) < distanceError &&
                timerBetweenPositions <= 0f)
            {
                computeTargetPosition();

                ghostDataIndex++;
                timerBetweenPositions = GhostGenerator.GetGhostGeneratorInstance.TimerRecordGhostTransform;

                distanceToMove = Vector3.Distance(transform.position, targetPosition);
                speed = distanceToMove / GhostGenerator.GetGhostGeneratorInstance.TimerRecordGhostTransform;
            }
        }
    }
}