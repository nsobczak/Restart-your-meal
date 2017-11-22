using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    [SerializeField]
    private float Speed = 6.0F;
    [SerializeField]
    private float JumpSpeed = 8.0F;
    [SerializeField]
    private float Gravity = 20.0F;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float right_left = Input.GetAxis("Horizontal");
        float forward_backward = Input.GetAxis("Vertical");
        Debug.Log("right_left : " + right_left);
        Debug.Log("forward_backward : " + forward_backward);
	}
}
