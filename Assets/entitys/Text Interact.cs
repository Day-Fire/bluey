using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextInteract : MonoBehaviour
{
    public enum InteractionType
    {
        // use if just needing a read of text
        Text,
        // use if options are going to appear
        Options
    }

    public InteractionType interactiontype;
    public abstract void callback(int page, int optionChoice, bool finished);
}
