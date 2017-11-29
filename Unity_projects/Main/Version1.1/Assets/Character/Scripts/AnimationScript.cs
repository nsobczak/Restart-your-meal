using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator animator;
    private MovementController movementController;

    void Start()
    {
        animator = GetComponent<Animator>();
        movementController = GetComponent<MovementController>();
    }

    void Update()
    {
    }
}