using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_display : MonoBehaviour
{
    private PlayerControls playercontrols;
    public TextMeshProUGUI MainTextDisp;
    public bool isVisible;
    public GameObject UI;
    public int Page;

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
    }

    public void Update()
    {
        UI.SetActive(isVisible);
    }

    //called by outside objects to start a display text chain
    public void startDisplaytext(string text, string[] options, TextInteract returnObj)
    {
        MainTextDisp.text = text;

        if (!isVisible)
        {
            isVisible = true;
        }
    }

    public void endDisplayText()
    {

    }

    //called by outside objects to display text without a chain
    public void displaytext(string text, string[] options)
    {
        MainTextDisp.text = text;

        if (!isVisible)
        {
            isVisible = true;
        }
    }

    //called internaly to get player interaction
    void interacttext()
    {
        if (isVisible)
        {
            isVisible = false;
        }
    }
}
