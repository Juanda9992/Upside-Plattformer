using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class modalWindowShow : MonoBehaviour
{
    [SerializeField]
    private Button[] modalWindowButtons;
    private bool isActive = false; 

    [SerializeField]
    private Transform showPosition;
    [SerializeField]
    private Transform hidePosition;


    public void displayWindow()
    {
        if(!isActive)
        {
            isActive = true;
            transform.DOMoveX(showPosition.position.x,0.4f).SetEase(Ease.OutCirc).OnComplete(ActivateButtons);
        }
        else
        {
            isActive = false;
            transform.DOMoveX(hidePosition.position.x,0.4f).SetEase(Ease.OutCirc).OnComplete(ActivateButtons);
        }
        
    }

    private void ActivateButtons()
    {
        foreach(var button in modalWindowButtons)
        {
            button.enabled = true;
        }
    }
}
