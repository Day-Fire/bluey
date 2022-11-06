using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteraction : Interactable
{
    public InteractionType InteractionType = InteractionType.Read;
    public string text;
    public bool isactive = false;
    public thirdPersonMovement movement;

    public override string getName()
    {
        return "Read";
    }

    public override void interact(GameObject player)
    {
        if (!isactive)
        {
            ui_display.displaytext(text);
            movement = player.GetComponent<thirdPersonMovement>();
            movement.canWalk = false;
            isactive = true;
        }
        else
        {
            ui_display.hidetext();
            movement = player.GetComponent<thirdPersonMovement>();
            movement.canWalk = true;
            isactive = false;
        }
    }
}
