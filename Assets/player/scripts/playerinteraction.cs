using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteraction : MonoBehaviour
{
    private PlayerControls playercontrols;
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

            if (interactable!= null)
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
            interactiontext.text = "";
        }
        
    }

    void handleInteraction(Interactable interactable)
    {
        switch (interactable.interactiontype)
        {
            case Interactable.InteractionType.Hold:
                interactable.interact();
                break;
            case Interactable.InteractionType.Read:
                interactable.interact();
                break;
            default:
                Debug.LogError("interaction type not found");
                break;
        }
    }
}
