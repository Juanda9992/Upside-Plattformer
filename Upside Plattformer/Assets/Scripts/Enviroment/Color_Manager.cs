using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Color_Manager : MonoBehaviour
{
    public static Color_Manager manager;
    public Color[] colors;
    public Color nextColor;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        manager = this;
    }
    public void ChangeColors()
    {
        nextColor = colors[Random.Range(0,colors.Length-1)];
        //spriteRenderer.DOColor(nextColor,0.7f).SetEase(Ease.OutQuart);
            
    }
}

