using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sled : Item
{

    [SerializeField]
    private thirdPersonMovement player;
    public override void use()
    {
        Debug.Log("loj");
        if (player.hardSetState(thirdPersonMovement.PlayerState.sled))
        {
            player.sledSpeed = player.sledStartSpeed;
            player.animator.SetTrigger("sled");
        }
    }
}
