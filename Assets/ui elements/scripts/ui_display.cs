using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_display : MonoBehaviour
{
    public static TextMeshProUGUI MainTextDisp;
    public static GameObject UI;

    public void Start()
    {
        UI = GetComponentInChildren<RawImage>().gameObject;
        MainTextDisp = GetComponentInChildren<TextMeshProUGUI>();
        UI.SetActive(false);
    }

    //called by outside objects to display text
    public static void displaytext(string text)
    {
        MainTextDisp.text = text;

        UI.SetActive(true);
    }

    public static void displaytextandopt(string text, string[] options)
    {
        MainTextDisp.text = text;

        UI.SetActive(true);
    }

    public static void hidetext()
    {
        MainTextDisp.text = "";

        UI.SetActive(false);
    }
}
