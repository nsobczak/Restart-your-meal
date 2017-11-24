using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGameOver : MonoBehaviour
{
    #region OnTrigger
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision player-ghost detected");
            //            Destroy(col.gameObject);

            GameController.IsGameOver = true;
        }
    }
    #endregion
}