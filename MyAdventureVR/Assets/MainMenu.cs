using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    //public XRNode inputSource;
    public XRController leftTeleportRay;
    public InputHelpers.Button menuButton;
    public GameObject mainMenu;
    public float activationThreshold = 0.1f;

    public AudioMixer audioMixer;

    private XRRig rig;
    private bool visible;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<XRRig>();
        visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mainMenu.SetActive(CheckIfActivated(leftTeleportRay));
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, menuButton, out bool isActivated, activationThreshold);
        return isActivated;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log("Volume");
    }




}
