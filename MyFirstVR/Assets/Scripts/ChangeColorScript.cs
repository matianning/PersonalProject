using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeColorScript : MonoBehaviour
{
    public Material red;
    public Material blue;
    public Material magenta;

    public void Red()
    {
        Debug.Log("red");
        GetComponent<MeshRenderer>().material = red;
    }

    public void Blue()
    {
        Debug.Log("blue");
        GetComponent<MeshRenderer>().material = blue;
    }

    public void Magenta()
    {
        Debug.Log("purple");
        GetComponent<MeshRenderer>().material = magenta;
    }
}