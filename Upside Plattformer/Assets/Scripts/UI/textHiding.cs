using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class textHiding : MonoBehaviour
{

    private TextMeshProUGUI scoreText;
    private GyroTest player;
    [SerializeField]
    private Color x2Color,x3Color,x4Color;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<GyroTest>();
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

    public void shakeText()
    {
        if(player.pointsInARow >0)
        {
            scoreText.transform.DOShakePosition(1.5f,2);
            if(player.pointsInARow ==2)
            {
                scoreText.DOColor(x2Color,0.3f).OnComplete(ResetColor).SetId("text");
            }
            else if(player.pointsInARow ==3)
            {
                scoreText.DOColor(x3Color,0.3f).OnComplete(ResetColor).SetId("text");
            }
        }
        
        
    }

    void OnEnable()
    {
        GyroTest.onScored += shakeText;
    }

    private void ResetColor()
    {
        scoreText.DOColor(Color.white,0.3f).SetDelay(0.6f);
    }
}
