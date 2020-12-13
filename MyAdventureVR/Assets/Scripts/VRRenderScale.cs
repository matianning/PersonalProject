using UnityEngine;
using UnityEngine.XR;

public class VRRenderScale : MonoBehaviour
{
    void Start()
    {
        //VRSettings.renderScale = 1.5f;
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 1.5f;
    }
}