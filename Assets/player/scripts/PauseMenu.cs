using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;

    [SerializeField]
    private GameObject UITotal;
    [SerializeField]
    private ParticleSystem Particle;
    [SerializeField]
    private thirdPersonMovement player;

    private PlayerControls playercontrols;

    private void Awake()
    {
        playercontrols = new PlayerControls();
    }

    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }
    private void Start()
    {
        Paused = false;

        playercontrols.normal.menu.performed += ctx => menu();
    }

    private void menu()
    {
        Paused = !Paused;
        UITotal.SetActive(Paused);
        if (Paused)
        {
            Time.timeScale = 0;
            Particle.Play();
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Time.timeScale = 1;
            Particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
