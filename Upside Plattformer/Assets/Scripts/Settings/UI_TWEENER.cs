using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UI_TWEENER : MonoBehaviour
{
    [SerializeField]
    private bool isFading = false;
    private TextMeshProUGUI textToFade;

    void Start()
    {
        Fade();
    }

    public void MoveX(float units)
    {
        if(!DOTween.IsTweening(transform))
        {
            transform.DOMoveX(transform.position.x + units,0.5f).SetEase(Ease.OutCirc);
        }
        
    }

    public void StopFading()
    {
        textToFade.DOPause();
        textToFade.DOFade(1,0);
    }

    void OnEnable()
    {
        Scene_Loader.onRestarted+=Fade;
    }
    private void Fade()
    {
        if(isFading)
        {
            textToFade = GetComponent<TextMeshProUGUI>();
            textToFade.DOFade(0.4f,1f).SetLoops(-1);
        }

    }
}
