using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public float FoVScale;
    public float FoV;
    public bool FullScreen;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeFoVScale(float NewFovScale)
    {
        FoVScale = NewFovScale/100;
        //Debug.Log("NFS: "+ FoVScale);
    }
    public void ChangeFoV(float NewFov)
    {
        FoV = NewFov;
        //Debug.Log("NFoV: " + FoV);
    }

    public void toggleFullscreen(bool NewFullscreen)
    {
        FullScreen = NewFullscreen;
        Screen.fullScreen = NewFullscreen;
    }

    public void invertX(bool ori)
    {

    }

}
