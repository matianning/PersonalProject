using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool walking = true;
    private Vector3 spawnPoint;
    private Camera mainCamera;
    public float speed = 1.5f;
  
    void Start()
    {
        mainCamera = Camera.main;
        spawnPoint = transform.position;
    }

    void Update()
    {
        if (walking)
        {
            transform.position += speed * mainCamera.transform.forward * 0.5f * Time.deltaTime;
        }

        if (transform.position.y < -10f)
        {
            transform.position = spawnPoint;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("Plane"))
            {
                walking = false;
            }
            else
            {
                walking = true;
            }
        }
        else
        {
            walking = true;     
        }
    }
}