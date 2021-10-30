using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdableBox : Interactable
{
    private PlayerControls playercontrols;
    public InteractionType InteractionType = InteractionType.Hold;
    public Player_Hold holdS;
    private bool held = false;

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
        playercontrols.normal.Action.started += _ => PutDown();
    }

    public override string getName()
    {
        return "hold";
    }

    public override void interact()
    {
        if (!held)
        {
            holdS.pickUp(gameObject);
            held = true;
        }
    }
    public void PutDown()
    {
        if (held)
        {
            holdS.setDown();
            held = false;
        }
    }

}
