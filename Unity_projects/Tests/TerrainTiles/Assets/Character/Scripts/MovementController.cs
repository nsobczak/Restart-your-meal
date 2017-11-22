using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float Speed = 6.0F;
    [SerializeField] private float RotationSpeed = 6.0F;

    [SerializeField] private float JumpSpeed = 18.0F;
    [SerializeField] private float Gravity = 20.0F;

    private Rigidbody rigid = null;
    private float right_left;
    private float forward_backward;
    private float jumpForce;
    private Vector3 forceMove;
    private bool grounding = false;
    private bool doubleJump = false;

    [SerializeField] private int distance = 2;
    private Vector3 direction;
    private RaycastHit hit;


    public float getSpeed()
    {
        return this.Speed;
    }


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    //raycast for double jump
    private bool isGrounding()
    {
        direction = Vector3.down;
        Debug.DrawRay(transform.position, direction * distance, Color.green);
        if (Physics.Raycast(origin: transform.position, direction: direction, hitInfo: out hit,
                maxDistance: distance) && hit.collider.gameObject.CompareTag("Terrain"))
            return true;
        return false;
    }


    void Update()
    {
        right_left = Input.GetAxis("Horizontal") * Speed;
        forward_backward = Input.GetAxis("Vertical") * Speed;
        jumpForce = 0;
        grounding = isGrounding();
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space");
            //Debug.Log("DoubleJump : " + doubleJump);
            if (!grounding && doubleJump)
            {
                Debug.Log("doubleJump");
                doubleJump = false;
                jumpForce = JumpSpeed;
            }
            else if (grounding)
            {
                Debug.Log("jump");
                jumpForce = JumpSpeed;
                doubleJump = true;
            }
        }
        forceMove.x = right_left;
        forceMove.z = forward_backward;
        if (jumpForce > 0)
        {
            rigid.AddForce(new Vector3(0, jumpForce, 0),
                ForceMode.Impulse); //50 is to avoid using ForceMode.Impulse which is 50 action per frame
            //rigid.AddForce(new Vector3(0, jumpForce, 0) * 50, ForceMode.Force); //50 is to avoid using ForceMode.Impulse which is 50 action per frame
        }
        rigid.AddForce(Vector3.down * Gravity /**Time.deltaTime*/, ForceMode.Force);
        forceMove.y = rigid.velocity.y;
        rigid.velocity = forceMove;

        //rotate
//        transform.rotation = Quaternion.LookRotation(new Vector3(forceMove.x, 0, forceMove.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.LookRotation(new Vector3(forceMove.x, 0, forceMove.z)), 2*Mathf.PI);
    }
}