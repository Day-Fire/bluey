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
<<<<<<< Updated upstream
        holdS = player.GetComponent<Player_Hold>();
        holdS.pickUp(gameObject);
=======
        col = this.GetComponent<Collider>();
        Follow = this.GetComponent<FollowPoint>();
        holdScript = player.GetComponent<Player_Hold>();
        Rigidbody rb = this.GetComponent<Rigidbody>();
        col.enabled = !col.enabled;
        rb.useGravity = !rb.useGravity;
        thirdPersonMovement pl = player.GetComponent<thirdPersonMovement>();

        if (pl.changeState(thirdPersonMovement.PlayerState.hold))
        {
            if (!col.enabled)
            {
                holdScript.pickUp(gameObject);
                isHeld = true;
                Follow.pointToFollow = holdpoint;
            }
            else
            {
                holdScript.setDownStart(col);
            }
        }
        
>>>>>>> Stashed changes
    }

}
