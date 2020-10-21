using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkController : MonoBehaviour
{

    public Transform vrCamera;
    public float toggleAngle = 20.0f;
    public float speed = 5.0f;
    public bool moveForward;

    private CharacterController cc;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    void Update()
    {
        //print(vrCamera.eulerAngles.x);
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            cc.SimpleMove(forward * speed);
        }
    }
}