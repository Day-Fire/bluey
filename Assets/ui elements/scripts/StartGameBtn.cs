using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameBtn : MonoBehaviour
{
    public Animator ani;
    public void startGame()
    {
        ani.SetTrigger("trans"); 
    }
}
