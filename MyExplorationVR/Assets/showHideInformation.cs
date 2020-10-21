using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHideInformation : MonoBehaviour
{
    public GameObject info;
    private bool show = true;

    public void showInfo()
    {
        if (!show)
        {
            info.SetActive(true);
            show = true;
        }
        else
        {
            info.SetActive(false);
            show = false;
        }
    }
}
