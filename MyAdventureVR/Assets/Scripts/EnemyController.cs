using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform goal;
    public NavMeshAgent agent;
    public GameObject finMenu;

    private bool isDead = false;
    public bool attraper;


    // Start is called before the first frame update
    void Start()
    {
        goal = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        GetComponent<Animation>().Play("zombie_walk_forward");
        //finMenu.setActive(false);
        attraper = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            agent.destination = goal.position;
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "Weapon" || col.GetComponent<Collider>().tag == "Bullet")
        {

            GetComponent<CapsuleCollider>().enabled = false;
            if(col.GetComponent<Collider>().tag == "Bullet")
            {
                Destroy(col.gameObject);
            }
            
            agent.destination = gameObject.transform.position;
            GetComponent<Animation>().Stop();
            GetComponent<Animation>().Play("zombie_death_standing");
            isDead = true;

            Destroy(gameObject, 5);
            GameObject zombie = Instantiate(Resources.Load("Zombie", typeof(GameObject))) as GameObject;

            float randomX = UnityEngine.Random.Range(-3.2f, 17f);
            float constantY = .01f;
            float randomZ = UnityEngine.Random.Range(15 , 34f);            
            zombie.transform.position = new Vector3(randomX, constantY, randomZ);


        }

        if(col.GetComponent<Collider>().tag == "Player")
        {
            attraper = true;
        }



    }

}
