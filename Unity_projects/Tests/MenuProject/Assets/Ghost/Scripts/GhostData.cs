using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostData : MonoBehaviour
{
    private Vector3 positionVector3;

    private Vector3 rotationVector3;

    public GhostData(Vector3 positionVector3, Vector3 rotationVector3)
    {
        this.positionVector3 = positionVector3;
        this.rotationVector3 = rotationVector3;
    }

    public Vector3 PositionVector3
    {
        get { return positionVector3; }
        set { positionVector3 = value; }
    }

    public Vector3 RotationVector3
    {
        get { return rotationVector3; }
        set { rotationVector3 = value; }
    }
}