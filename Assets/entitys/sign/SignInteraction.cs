using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteraction : Interactable
{
    private PlayerControls playercontrols;
    public InteractionType InteractionType = InteractionType.Read;
    public string text;
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
        movement = player.GetComponent<thirdPersonMovement>();
        if (!isactive)
        {
            //ui_display.displaytext(text, new string[0]);
            isactive = true;
        }
        else
        {
            isactive = false;
        }
        movement.canWalk = !isactive;
    }
}
