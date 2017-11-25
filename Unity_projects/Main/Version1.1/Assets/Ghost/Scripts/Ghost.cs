using System;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    #region Parameters
    private static int ghostGhostInstanceCount = 0;

    private List<Vector3> positions;
    private List<Quaternion> rotations;
    #endregion

    #region ConstructorDestructor
    public Ghost()
    {
        Debug.Log("new ghost created");
        this.positions = new List<Vector3>();
        this.rotations = new List<Quaternion>();
        ghostGhostInstanceCount++;
    }

    ~Ghost()
    {
        ghostGhostInstanceCount--;
    }
    #endregion

    #region GetSet
    public static int GhostGhostInstanceCount
    {
        get { return ghostGhostInstanceCount; }
        //set { ghostGhostInstanceCount = value; }
    }

    public List<Vector3> Positions
    {
        get { return positions; }
    }

    public List<Quaternion> Rotations
    {
        get { return rotations; }
    }

    public Vector3 getPosition_i(int index)
    {
        return positions[index];
    }

    public Quaternion getRotation_i(int index)
    {
        return rotations[index];
    }
    #endregion

    #region Methods
    public void addTransformData(Transform transform)
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        this.positions.Add(newPosition);
        this.rotations.Add(newRotation);
        //Debug.Log(" position : " + position);
    }
    #endregion

    #region Overrides
    //public override string ToString()
    //{
    //    String list = "";
    //    foreach (Vector3 ghostData in positions)
    //    {
    //        list += "pos: " + ghostData.x + ", " + ghostData.y + ", " +
    //                ghostData.z + " |";
    //    }
    //    return base.ToString() + list;
    //}
    #endregion
}
