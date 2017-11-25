using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableFood : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = 10f;
    
    
    void Update()
    {
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("collision with player detected");
            Destroy(gameObject);
            
            GameController.CollectableFoodCount++;
        }
    }
}