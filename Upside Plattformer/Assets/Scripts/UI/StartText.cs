using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{
    public TextMeshProUGUI text;

    private float secondsToStart = 3;
    private float currentSecond = 1;

    [SerializeField]
    private GameObject firstPlaftorm;
    [SerializeField]
    private float ascendSpeed= 2;

    private bool gameStarted = false;

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            if(currentSecond < 0)
            {
                currentSecond = 1;
                secondsToStart--;
                text.text = secondsToStart.ToString();
            }
            else
            {
                currentSecond-= Time.deltaTime;
            }

            if(secondsToStart > 0)
            {
                firstPlaftorm.transform.Translate(Vector2.up * ascendSpeed * Time.deltaTime);
            }
            else
            {   
                gameStarted = true;
                firstPlaftorm.SetActive(false);
            }
        }

    }
}
