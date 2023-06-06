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
        col = this.GetComponent<Collider>();
        Follow = this.GetComponent<FollowPoint>();
        holdScript = player.GetComponent<Player_Hold>();
        if (player.GetComponent<thirdPersonMovement>().changeState(thirdPersonMovement.PlayerState.hold))
        {
            holdScript.pickUp(gameObject);
            isHeld = true;
        }
        col.enabled = !col.enabled;
        Follow.pointToFollow = holdpoint;
    }

}
