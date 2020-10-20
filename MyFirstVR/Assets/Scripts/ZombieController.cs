using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
    private Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;


    void Start()
    {

        goal = Camera.main.transform;
        
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //set the navmesh agent's desination equal to the main camera's position (our first person character)
        agent.destination = goal.position;
        
        GetComponent<Animation>().Play("zombie_walk_forward");
    }


    //for this to work both need colliders, one must have rigid body, and the zombie must have is trigger checked.
    
    void OnTriggerEnter(Collider col)
    {
        //first disable the zombie's collider so multiple collisions cannot occur
        GetComponent<CapsuleCollider>().enabled = false;
        //destroy the bullet
        Destroy(col.gameObject);
        //stop the zombie from moving forward by setting its destination to it's current position
        agent.destination = gameObject.transform.position;

        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("zombie_death_standing");
        Destroy(gameObject, 6);

        //instantiate a new zombie
        GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;
        float randomX = UnityEngine.Random.Range(-12f, 12f);
        float constantY = -1.0f;
        float randomZ = UnityEngine.Random.Range(-13f, 13f);
        zombie.transform.position = new Vector3(randomX, constantY, randomZ);

        //if the zombie gets positioned less than or equal to 3 scene units away from the camera we won't be able to shoot it
        //so keep repositioning the zombie until it is greater than 3 scene units away. 
        while (Vector3.Distance(zombie.transform.position, Camera.main.transform.position) <= 3)
        {

            randomX = UnityEngine.Random.Range(-12f, 12f);
            randomZ = UnityEngine.Random.Range(-13f, 13f);

            zombie.transform.position = new Vector3(randomX, constantY, randomZ);
        }

    }
    /*
    public void Action()
    {
        //first disable the zombie's collider so multiple collisions cannot occur
        GetComponent<CapsuleCollider>().enabled = false;
       
        //stop the zombie from moving forward by setting its destination to it's current position
        //agent.destination = gameObject.transform.position;


        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("zombie_death_standing");
        //Destroy(gameObject, 6);

        //instantiate a new zombie
        GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;
        float randomX = UnityEngine.Random.Range(-12f, 12f);
        float constantY = .01f;
        float randomZ = UnityEngine.Random.Range(-13f, 13f);
        zombie.transform.position = new Vector3(randomX, constantY, randomZ);

        //if the zombie gets positioned less than or equal to 3 scene units away from the camera we won't be able to shoot it
        //so keep repositioning the zombie until it is greater than 3 scene units away. 
        while (Vector3.Distance(zombie.transform.position, Camera.main.transform.position) <= 3)
        {

            randomX = UnityEngine.Random.Range(-12f, 12f);
            randomZ = UnityEngine.Random.Range(-13f, 13f);

            zombie.transform.position = new Vector3(randomX, constantY, randomZ);
        }
    }
    */

}