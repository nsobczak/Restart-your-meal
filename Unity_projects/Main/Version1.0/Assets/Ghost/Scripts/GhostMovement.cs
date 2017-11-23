using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    #region Parameters

    private Ghost ghost;
    [SerializeField] private bool isGhostMoving;
    [SerializeField] private int ghostDataIndex; // index in list of positions and rotation of the ghost

    [SerializeField] private float distanceError;
    private float positionOffset;
    private float speed;

    private float timerBetweenPositions;
    private float distanceToMove;
    private Vector3 targetPosition;
    private Vector3 newDir;

    #endregion

    #region Constructor

    public GhostMovement(Ghost ghost)
    {
        this.ghost = ghost;
    }

    #endregion

    #region GetSet

    public Ghost Ghost
    {
        get { return ghost; }
        set { ghost = value; }
    }

    #endregion

    #region Methods

    private void computeTargetPosition()
    {
        targetPosition = new Vector3(ghost.getPosition_i(ghostDataIndex).x,
            ghost.getPosition_i(ghostDataIndex).y + positionOffset,
            ghost.getPosition_i(ghostDataIndex).z);
    }

    #endregion

    void Start()
    {
        isGhostMoving = true;

        distanceError = 0.01f;
        timerBetweenPositions = GhostGenerator.GetGhostGeneratorInstance.TimerRecordGhostTransform;
        positionOffset = GameObject.FindObjectOfType<GhostGenerator>().PositionOffset;
        ghostDataIndex = 1;

        computeTargetPosition();

        distanceToMove = Vector3.Distance(transform.position, targetPosition);
        speed = distanceToMove / GhostGenerator.GetGhostGeneratorInstance.TimerRecordGhostTransform;
    }


    void Update()
    {
        if (isGhostMoving && ghostDataIndex < ghost.Positions.Count)
        {
            //moveGhost
            timerBetweenPositions -= Time.deltaTime;

            //translate
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            //rotate
            newDir = Vector3.RotateTowards(Vector3.forward, targetPosition - transform.position,
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