using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdableBox : Interactable
{
    private PlayerControls playercontrols;
    public InteractionType InteractionType = InteractionType.Hold;
    private Player_Hold holdS;

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
    }

    public override string getName()
    {
        return "hold";
    }

    public override void interact(GameObject player)
    {
        holdS = player.GetComponent<Player_Hold>();
        holdS.pickUp(gameObject);
    }

}
