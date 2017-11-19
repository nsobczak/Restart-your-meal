using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private static int ghostGhostInstanceCount = 0;

    private List<GhostData> ghostDataList;

    //___________________________________________

    public Ghost()
    {
        this.ghostDataList = new List<GhostData>();
        ghostGhostInstanceCount++;
    }

    ~Ghost()
    {
        ghostGhostInstanceCount--;
    }


    public static int GhostGhostInstanceCount
    {
        get { return ghostGhostInstanceCount; }
        set { ghostGhostInstanceCount = value; }
    }

    public List<GhostData> GhostDataList
    {
        get { return ghostDataList; }
        set { ghostDataList = value; }
    }


    public Vector3 getPositionVector(int index)
    {
        return ghostDataList[index].PositionVector3;
    }

    public Vector3 getRotationVector(int index)
    {
        return ghostDataList[index].RotationVector3;
    }

    public Quaternion GetRotationQuaternion(int index)
    {
        return Quaternion.Euler(ghostDataList[index].RotationVector3);
    }


    public override string ToString()
    {
        String list = "";
        foreach (GhostData ghostData in ghostDataList)
        {
            list += "pos: " + ghostData.PositionVector3.x + ", " + ghostData.PositionVector3.y + ", " +
                    ghostData.PositionVector3.z + " |" + " /|\\ rotation: " + ghostData.RotationVector3.x + ", " +
                    ghostData.RotationVector3.y + ", " +
                    ghostData.RotationVector3.z + " |";
        }
        return base.ToString() + list;
    }


    public void addTransformData(Transform transform)
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 rotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        this.ghostDataList.Add(new GhostData(position, rotation));
    }
}