using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public EnemyController[] ennemies;
    public GameObject finMenu;
    
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (ennemies[i].attraper)
            {
                SceneManager.LoadScene("Fin");
            }
        }
    }






}
