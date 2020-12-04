using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClimbSceneChange : MonoBehaviour
{
    public LevelLoader levelLoader;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "VR Rig")
        {
            if(levelLoader!=null)
                levelLoader.LoadLevel();
            
        }
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
