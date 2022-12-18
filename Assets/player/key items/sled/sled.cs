using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sled : Item
{

    [SerializeField]
    private thirdPersonMovement player;
    public override void use()
    {
        /*
        if (player.isSleding == false)
        {
            player.isSleding = true;
            player.canroll = false;
            player.sledSpeed = player.sledSpeedMax * 0.75f;
            player.animator.SetTrigger("sled");
        }
        */
    }
}
