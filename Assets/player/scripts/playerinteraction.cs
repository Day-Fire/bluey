using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteraction : MonoBehaviour
{
    private PlayerControls playercontrols;

    [SerializeField]
    private Player_stats Stats;

    [SerializeField]
    private thirdPersonMovement movement;

    public float interactiondistance;
    public TMPro.TextMeshProUGUI interactiontext;

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

    void Update()
    {
        RaycastHit hit;
        bool succsesfulhit = false;

        if (Physics.Raycast(transform.position, transform.right * -1, out hit, interactiondistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                if (playercontrols.normal.Action.triggered)
                {
                    handleInteraction(interactable);
                }
                interactiontext.text = interactable.getName();
                succsesfulhit = true;
            }
        }

        if (!succsesfulhit)
        {
            if (movement.canroll)
            {
                interactiontext.text = "roll";
            }
            if (playercontrols.normal.Action.triggered)
            {
                movement.canMove = true;
                movement.roll();
            }
        }
    }

    void handleInteraction(Interactable interactable)
    {
        switch (interactable.interactiontype)
        {
            case Interactable.InteractionType.Hold:
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
