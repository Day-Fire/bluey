using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleManager : MonoBehaviour
{
    public ButtonManager[] btns;

    public Image btn;
    public Button btno;
    public TextMeshProUGUI oof;
    public Image btn2;
    public Button btno2;
    public TextMeshProUGUI oof2;
    public bool isVis;
    private float opacity = 1f; 

    public void pressStart()
    {
        Debug.Log("oof");
        isVis = false;
    }

    private void moveSaves()
    {
        foreach (ButtonManager btn in btns)
        {
            btn.isActive = true;
        }
    }

    private void Update()
    {
        if (isVis)
        {
            btno.interactable = true;
            btn.color = new Color(255, 255, 255, Mathf.Lerp(btn.color.a, 0.32f, 0.05f));
            oof.color = new Color(oof.color.r, oof.color.g, oof.color.b, Mathf.Lerp(oof.color.a, 1, 0.03f));

            btno2.interactable = true;
            btn2.color = new Color(255, 255, 255, Mathf.Lerp(btn2.color.a, 0.32f, 0.05f));
            oof2.color = new Color(oof2.color.r, oof2.color.g, oof2.color.b, Mathf.Lerp(oof2.color.a, 1, 0.03f));
        }
        else
        {
            btno.interactable = false;
            btn.color = new Color(255, 255, 255, Mathf.Lerp(btn.color.a, 0, 0.12f));
            oof.color = new Color(oof.color.r, oof.color.g, oof.color.b, Mathf.Lerp(oof.color.a, 0, 0.12f));

            btno2.interactable = false;
            btn2.color = new Color(255, 255, 255, Mathf.Lerp(btn2.color.a, 0, 0.12f));
            oof2.color = new Color(oof2.color.r, oof2.color.g, oof2.color.b, Mathf.Lerp(oof2.color.a, 0, 0.12f));
        }

        if(btn.color.a < 0.1)
        {
            moveSaves();
        }
    }
}
