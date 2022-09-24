using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public Transform btn;
    public Transform trgt1;
    public Transform trgt2;
    public Vector3 velocity;
    public float damping;
    public float speed;
    public bool isActive;
    private Button button;
    private Image img;
    public TextMeshProUGUI[] txt;

    private void Start()
    {
        if (gameObject.GetComponentInChildren<Button>() != null)
        {
            button = gameObject.GetComponentInChildren<Button>();
        }
        img = gameObject.GetComponentInChildren<Image>();
    }
    void Update()
    {
        if (isActive)
        {
            velocity += (trgt1.position - btn.position) / speed;
            velocity = Vector3.Lerp(velocity, Vector3.zero, damping);
            btn.position += velocity * Time.deltaTime;

            if (button != null)
            {
                button.interactable = true;
            }
            img.color = new Color(0, 0, 0, Mathf.Lerp(img.color.a, 0.32f, 0.05f));
            foreach (TextMeshProUGUI x in txt)
            {
                x.color = new Color(x.color.r, x.color.g, x.color.b, Mathf.Lerp(x.color.a, 255, 0.03f));
            }
        }
        else
        {
            velocity += (trgt2.position - btn.position) / speed;
            velocity = Vector3.Lerp(velocity, Vector3.zero, damping);
            btn.position += velocity * Time.deltaTime;
            
            if (button != null)
            {
                button.interactable = false;
            }
            img.color = new Color(0, 0, 0, Mathf.Lerp(img.color.a, 0, 0.12f));
            foreach (TextMeshProUGUI x in txt)
            {
                x.color = new Color(x.color.r, x.color.g, x.color.b, Mathf.Lerp(x.color.a, 0, 0.12f));
            }
        }
    }
}
