using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : Interactable
{
    private PlayerControls playercontrols;
    public InteractionType InteractionType = InteractionType.Read;
    public string text;
    public GameObject ui_display;
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
        ui_display distext = ui_display.GetComponent<ui_display>();
        Debug.Log(player.GetComponent<thirdPersonMovement>());
        {
            movement = player.GetComponent<thirdPersonMovement>();
        }
        if (!isactive)
        {
            //distext.displaytext(text);
            isactive = true;
        }
        else
        {
            isactive = false;
        }
        movement.canWalk = !isactive;
    }
}
