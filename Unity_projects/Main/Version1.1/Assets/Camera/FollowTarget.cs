using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Transform target;

    [SerializeField]
    private Vector3 distance;
    [SerializeField]
    private float smoothTime;
    private Vector3 Velocity;


    //==================

    private Transform prevTransObject;
    private Material prevObjectMaterial;
    public float alphaValue = 0.5f; // our alpha value
    public List<int> transparentLayers = new List<int>();   // transparency layers.
    //=====================

    // Use this for initialization
    void Start()
    {
        var speed = target.GetComponent<MovementController>().GetSpeed();
        Velocity = new Vector3(speed, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position - distance, ref Velocity, smoothTime);

        // Cast ray from camera.position to target.position and check if the specified layers are between them.
        Ray ray = new Ray(transform.position, (target.position - transform.position).normalized);
        RaycastHit transHit;
        Debug.DrawRay(transform.position, (target.position - transform.position), Color.green);
        if (Physics.Raycast(ray, out transHit, Vector3.Distance(transform.position, target.position)))
        {
            Transform objectHit = transHit.transform;
            if (transparentLayers.Contains(objectHit.gameObject.layer))
            {

                if (prevTransObject != null)
                {
                    var colo = prevObjectMaterial.color;
                    prevObjectMaterial.color = new Color(prevObjectMaterial.color.r, prevObjectMaterial.color.g, prevObjectMaterial.color.b, 1);
                }

                if (objectHit.GetComponent<MeshRenderer>() != null)
                {
                    Debug.Log("Hit");
                    prevTransObject = objectHit;
                    prevObjectMaterial = prevTransObject.GetComponent<MeshRenderer>().material;
                    // Can only apply alpha if this material shader is transparent.
                    var colo = prevObjectMaterial.color;
                    prevObjectMaterial.color = new Color(prevObjectMaterial.color.r, prevObjectMaterial.color.g, prevObjectMaterial.color.b, alphaValue);
                }
            }
            else if (prevTransObject != null)
            {
                var colo = prevObjectMaterial.color;
                prevObjectMaterial.color = new Color(prevObjectMaterial.color.r, prevObjectMaterial.color.g, prevObjectMaterial.color.b, 1);
                prevTransObject = null;
            }
        }
    }



}
