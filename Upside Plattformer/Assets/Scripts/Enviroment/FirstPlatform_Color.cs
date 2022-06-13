using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlatform_Color : MonoBehaviour
{
    SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    private void UpdateColor()
    {
        sRenderer.color = Color_Manager.manager.nextColor;
    }

    void OnEnable()
    {
        Scene_Loader.onRestarted += UpdateColor;
    }

    void OnDisable()
    {
        Scene_Loader.onRestarted -= UpdateColor;
    }
}
