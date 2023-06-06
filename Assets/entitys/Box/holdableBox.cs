using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdableBox : Interactable
{
    public InteractionType InteractionType = InteractionType.Hold;
    private Player_Hold holdScript;

    private Collider col;
    public bool isHeld = false;
    private FollowPoint Follow;
    public Transform holdpoint;
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
