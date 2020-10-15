using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 280.0f;
    public enum Mode {Shooter, Adventure};
    public Mode mode = Mode.Shooter;

    float horizontal;
    float vertical;

    private void Update()
    {
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;

        Vector3 projectedCameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        Quaternion rotationToCamera = Quaternion.LookRotation(projectedCameraForward, Vector3.up);


        

        moveDirection = rotationToCamera * moveDirection;
        Quaternion rotationToMoveDirection = Quaternion.LookRotation(moveDirection, Vector3.up);

        if(mode == Mode.Adventure)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToMoveDirection, rotationSpeed * Time.deltaTime);
        if(mode == Mode.Shooter)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToCamera, rotationSpeed * Time.deltaTime);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        
    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        this.horizontal = horizontal;
        this.vertical = vertical;
        //Debug.Log($"Player Controller - Move Input : {vertical}, {horizontal}");
    }


}
