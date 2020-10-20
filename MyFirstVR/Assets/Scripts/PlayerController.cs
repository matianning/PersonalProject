using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    
    public GameObject gun;
    public GameObject spawnPoint;
    
    private bool isShooting;
    private float bulletForce = 1000f;

    void Start()
    {
        isShooting = false;
    }

    //Shoot function is IEnumerator so we can delay for seconds
    IEnumerator Shoot()
    {
        
        isShooting = true;

        GameObject bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = spawnPoint.transform.rotation;
        bullet.transform.position = spawnPoint.transform.position;
        rb.AddForce(spawnPoint.transform.forward * bulletForce);

        GetComponent<AudioSource>().Play();
        gun.GetComponent<Animation>().Play();

        Destroy(bullet, 1);

        yield return new WaitForSeconds(1f);
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {

        //declare a new RayCastHit
        RaycastHit hit;
        //draw the ray for debuging purposes (will only show up in scene view)
        //Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green);

        //cast a ray from the spawnpoint in the direction of its forward vector
        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, 100))
        {
            if (hit.collider.name.Contains("zombie"))
            {
                if (!isShooting)
                {
                    StartCoroutine("Shoot");
                }

            }
            
            /*
            //if the raycast hits any game object where its name contains "zombie" and we aren't already shooting we will start the shooting coroutine
            if (hit.collider.name.Contains("zombie"))
            {
                if (!isShooting)
                {
                    StartCoroutine("Shoot");
                }

            }
            */
        }

    }
}