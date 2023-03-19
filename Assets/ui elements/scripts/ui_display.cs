using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_display : MonoBehaviour
{
    private PlayerControls playercontrols;
    public TextMeshProUGUI MainTextDisp;
    public bool IsVisible;
    public GameObject UI;
    public int Page;

    private void Awake()
    {
        playercontrols = new PlayerControls();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    void Start()
    {
        playercontrols.normal.Action.performed += _ => interacttext();
    }

    //called by outside objects to display text
    public void displaytext(string text)
    {
        if (!IsVisible)
        {
            MainTextDisp.text = text;
            IsVisible = true;
        }
    }

    //called internaly to get player interaction
    void interacttext()
    {
        if (IsVisible)
        {
            IsVisible = false;
        }
    }
}
