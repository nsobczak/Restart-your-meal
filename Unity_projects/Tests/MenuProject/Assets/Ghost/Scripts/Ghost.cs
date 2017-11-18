using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private List<GhostData> ghostDataList;

    //___________________________________________

    public Ghost()
    {
        this.ghostDataList = new List<GhostData>();
    }

    public override string ToString()
    {
        String list = "";
        foreach (GhostData ghostData in ghostDataList)
        {
            list += "pos: " + ghostData.PositionVector3.x + ", " + ghostData.PositionVector3.y + ", " +
                    ghostData.PositionVector3.z + " |";
        }
        return base.ToString() + list;
    }

    public void addTransformData(Transform transform)
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        this.ghostDataList.Add(new GhostData(position, rotation));
    }
}