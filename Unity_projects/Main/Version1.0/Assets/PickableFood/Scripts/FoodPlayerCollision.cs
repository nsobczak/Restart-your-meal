using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision with player detected");
            Destroy(gameObject);
            GameController.CollectableFoodCount++;
        }
    }
}