using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineFovEditor : MonoBehaviour
{
    private CinemachineFreeLook cam;
    public float baseFOV;
    public float EffectSpeed;
    private float FOV;
    private float FOVmods;
    private float wantedFOV;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<CinemachineFreeLook>();
        cam.m_CommonLens = true;
        cam.m_Lens.FieldOfView = baseFOV;
        FOV = baseFOV;
    }

    // Update is called once per frame
    void Update()
    {
        wantedFOV = baseFOV + FOVmods;
        FOV = Mathf.Lerp(FOV, wantedFOV, EffectSpeed);
        cam.m_Lens.FieldOfView = FOV;
    }

    public void changeFov(float amt)
    {
        FOVmods = amt;
    }

    public void resetFov()
    {
        FOVmods = 0;
    }
}
