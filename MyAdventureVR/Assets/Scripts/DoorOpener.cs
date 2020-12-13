using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{

    public Transform door;
    public Quaternion closedRotation; 
    public Quaternion openedRotation; 


    public float openSpeed = 3;
    private bool open = false;
    private Vector3 angle = new Vector3(0.0f, 90.0f, 0.0f);

    private void Start()
    {
        
    }

    void Update()
    {
        if (open)
        {
            var fromAngle = door.transform.rotation;
            var toAngle = Quaternion.Euler(transform.eulerAngles + angle);
            door.rotation = Quaternion.Slerp(fromAngle, toAngle, Time.deltaTime * openSpeed);
            
        }
        else
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("triggered");
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            CloseDoor();
        }
    }

    public void CloseDoor()
    {
        open = false;
    }

    public void OpenDoor()
    {
        open = true;
    }
}
