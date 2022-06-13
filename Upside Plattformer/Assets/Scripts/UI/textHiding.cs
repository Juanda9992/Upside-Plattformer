using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class textHiding : MonoBehaviour
{

    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.parent.GetComponentInChildren<TextMeshProUGUI>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            scoreText.DOFade(0.3f,0.4f).SetEase(Ease.OutCirc);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            scoreText.DOFade(1f,0.4f).SetEase(Ease.OutCirc);
        }
    }
}
