using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("Adventure");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
