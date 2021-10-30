using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteraction : Interactable
{
    private PlayerControls playercontrols;
    public InteractionType InteractionType = InteractionType.Read;
    public string text;
    public GameObject ui_display;
    public bool isactive = false;
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

    public override string getName()
    {
        return "Read";
    }

    public override void interact()
    {
        var distext = ui_display.GetComponent<ui_display>();
        if (!isactive)
        {
            distext.displaytext(text);
            isactive = true;
        }
        else
        {
            isactive = false;
        }
    }
}
