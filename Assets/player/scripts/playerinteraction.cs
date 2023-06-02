using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerinteraction : MonoBehaviour
{
    private PlayerInput playercontrols;

    [SerializeField]
    private Player_stats Stats;

    [SerializeField]
    private thirdPersonMovement movement;

    public float interactiondistance;
    public TMPro.TextMeshProUGUI interactiontext;
<<<<<<< Updated upstream
=======
    public bool InteractionHold = false;
    private Interactable HeldInteraction;
>>>>>>> Stashed changes

    private void Awake()
    {
        playercontrols = gameObject.GetComponent<PlayerInput>();
    }

    void Update()
    {
        RaycastHit hit;
        bool succsesfulhit = false;

        if (!InteractionHold)
        {
            HeldInteraction = null;
        }

        if (InteractionHold)
        {
            if (playercontrols.actions["Action"].triggered)
            {
                //Debug.Log("bitch1" + HeldInteraction.name);
                handleInteraction(HeldInteraction);
            }
        }
        else if (Physics.Raycast(transform.position, transform.right * -1, out hit, interactiondistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                if (playercontrols.actions["Action"].triggered)
                {
                    handleInteraction(interactable);
                }
                interactiontext.text = interactable.getName();
                succsesfulhit = true;
            }
        }

        if (!succsesfulhit)
        {
            /*
            if (movement.canroll)
            {
                interactiontext.text = "roll";
            }
            if (playercontrols.actions["Action"].triggered)
            {
                movement.canWalk = true;
                movement.roll();
            }
            */
        }
    }

    void handleInteraction(Interactable interactable)
    {
        switch (interactable.interactiontype)
        {
            case Interactable.InteractionType.Hold:
                HeldInteraction = interactable;
                InteractionHold = true;
                interactable.interact(gameObject);
                break;
            case Interactable.InteractionType.Read:
                interactable.interact(gameObject);
                break;
            default:
                Debug.LogError("interaction type not found");
                break;
        }
    }
}
