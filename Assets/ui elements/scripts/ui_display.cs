using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_display : MonoBehaviour
{
    private PlayerControls playercontrols;
    public TMPro.TextMeshProUGUI textdisp;
    public bool displaying = false;
    public GameObject ui;

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

    void Start()
    {
        playercontrols.normal.Action.performed += _ => interacttext();
        ui.SetActive(false);
    }

    public void displaytext(string text)
    {
        if (!displaying)
        {
            ui.SetActive(true);
            textdisp.text = text;
            displaying = true;
        }
    }

    void interacttext()
    {
        if (displaying)
        {
           ui.SetActive(false);
            displaying = false;
        }
    }
}
