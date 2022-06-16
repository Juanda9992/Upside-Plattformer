using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Color : MonoBehaviour
{
    private FlexibleColorPicker picker;
    private SpriteRenderer playerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        picker = GameObject.FindObjectOfType<FlexibleColorPicker>();
        playerRenderer = GetComponent<SpriteRenderer>();

    }

    public void changeColor()
    {
        playerRenderer.color = picker.color;
    }
}
