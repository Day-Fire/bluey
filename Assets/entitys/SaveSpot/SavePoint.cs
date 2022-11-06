using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SavePoint : Interactable
{
    public InteractionType InteractionType = InteractionType.Read;
    public bool isactive = false;
    public thirdPersonMovement movement;
    public DataManager DMgr;
    public override string getName()
    {
        return "Read";
    }

    public override void interact(GameObject player)
    {
        if (!isactive)
        {
            ui_display.displaytext("saving...");
            movement = player.GetComponent<thirdPersonMovement>();
            movement.canWalk = false;
            DMgr.saveData(1);
            isactive = true;
            ui_display.displaytext("done");
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
