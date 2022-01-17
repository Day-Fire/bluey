using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sled : Item
{
    [SerializeField]
    private thirdPersonMovement player;
    public override void use()
    {
        player.isSleding = true;
        player.animator.SetTrigger("sled");
    }
}
