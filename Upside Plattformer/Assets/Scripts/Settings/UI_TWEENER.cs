using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_TWEENER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void MoveX(float units)
    {
        transform.DOMoveX(transform.position.x + units,0.5f).SetEase(Ease.OutCirc);
    }
}
