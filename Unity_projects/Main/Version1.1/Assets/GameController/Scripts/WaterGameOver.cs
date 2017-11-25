using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGameOver : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (!GameController.IsLevelCompleted && col.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision player-water detected");
//            Destroy(col.gameObject);
            
            GameController.IsGameOver = true;
        }
    }
}