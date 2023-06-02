using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteraction : Interactable
{
    private PlayerControls playercontrols;
    public InteractionType InteractionType = InteractionType.Read;
    public string text;
    public GameObject DialougeManager;
    public bool isactive = false;
    public thirdPersonMovement movement;

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

    public override void interact(GameObject player)
    {
        ui_display distext = DialougeManager.GetComponent<ui_display>();
        movement = player.GetComponent<thirdPersonMovement>();
        if (!isactive)
        {
            distext.displaytext(text);
            isactive = true;
        }
        else
        {
            isactive = false;
        }
        movement.standStill();
    }
}
