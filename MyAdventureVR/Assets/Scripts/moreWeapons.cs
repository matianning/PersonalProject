using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moreWeapons : MonoBehaviour
{
    public GameObject gun;
    public GameObject axe;
    public GameObject cube;

    public void generateWeapon()
    {
        float randomNumber = Random.Range(0.0f, 100.0f);
        if (randomNumber < 15.0)
        {
            Instantiate(cube);
        }
        else if (randomNumber >= 15.0 && randomNumber < 30.0)
        {
            Instantiate(gun);
        }
        else
        {
            Instantiate(axe);
        }
                
    }
}
