using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string getName() 
    {
        return gameObject.name;
    }
    public abstract void use();
}
