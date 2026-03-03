using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class InitialMessageAnimation : MonoBehaviour
{
    [SerializeField] private float maxScaleThreshold;
    [SerializeField] private float timeToAnimate;
    [SerializeField] private TextMeshProUGUI textToAnimate;
    [SerializeField] private Color32 randomColor;
    IEnumerator Start()
    {
        randomColor = Random.ColorHSV(0.5f, 1, 0.5f, 1, 0.5f, 1);

        transform.DOScale(maxScaleThreshold, timeToAnimate).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        while (true)
        {
            textToAnimate.DOColor(randomColor, timeToAnimate);
            randomColor = Random.ColorHSV(0f, 1, 0.1f, 1, 0.8f, 1);
            yield return new WaitForSeconds(timeToAnimate);
        }
    }
}
