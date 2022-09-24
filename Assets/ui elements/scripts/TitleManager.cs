using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleManager : MonoBehaviour
{
    public GameObject[] saveButtons;
    public GameObject[] mainButtons;
    public GameObject[] infoButtons;

    public Image btn;
    public int state;

    public void pressStart()
    {
        state = 1;
    }

    public void selectSave()
    {
        state = 2;
    }

    private void Update()
    {
        switch (state) {
            case 0:
                changeActivationOfGroup(mainButtons, true);
                changeActivationOfGroup(saveButtons, false);
                changeActivationOfGroup(infoButtons, false);
                break;
            case 1:
                changeActivationOfGroup(mainButtons, false);
                changeActivationOfGroup(saveButtons, true);
                changeActivationOfGroup(infoButtons, false);
                break;
            case 2:
                changeActivationOfGroup(mainButtons, false);
                changeActivationOfGroup(saveButtons, false);
                changeActivationOfGroup(infoButtons, true);
                break;
        }
    }

    public void changeActivationOfGroup(GameObject[] btns, bool isactive)
    {
        foreach (GameObject btn in btns)
        {
            btn.GetComponent<ButtonManager>().isActive = isactive;
        }
    }
}
