using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Hold,
        Read
    }

    public InteractionType interactiontype;

    public abstract string getName();
    public abstract void interact();
}
