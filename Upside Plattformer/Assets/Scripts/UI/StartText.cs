using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{
    public TextMeshProUGUI text;

    private GyroTest gyro;

    private float secondsToStart = 3;
    private float currentSecond = 1;

    [SerializeField]
    private GameObject firstPlaftorm;
    private Vector3 firstPlatformPosition;
    [SerializeField]
    private float ascendSpeed= 2;

    private bool gameStarted;

    void Start()
    {
        gyro = GameObject.FindObjectOfType<GyroTest>();
        firstPlatformPosition = firstPlaftorm.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        gameStarted = Scene_Loader.hasLosed;
        if(gameStarted)
        {
            text.fontSize = 800;
            if(currentSecond < 0)
            {
                currentSecond = 1;
                secondsToStart--;
                
            }
            else
            {
                currentSecond-= Time.deltaTime;
            }

            if(secondsToStart >= 0)
            {
                text.text = secondsToStart.ToString();
                firstPlaftorm.transform.Translate(Vector2.up * ascendSpeed * Time.deltaTime);
            }
            else
            {   
                gameStarted = false;
                firstPlaftorm.transform.position = Vector2.one * 100;
            }
        }
        else if(!gameStarted && secondsToStart > 0)
        {
            text.fontSize = 200;
            text.text = "TOUCH THE SCREEN TO PLAY";
        }

    }

    public void UpdateText()
    {
        text.text = gyro.score.ToString();
    }

    private void ResetStats()
    {
        firstPlaftorm.transform.position = firstPlatformPosition;
        secondsToStart = 3;
        currentSecond = 1;
        gameStarted = false;
    }


    void OnEnable()
    {
        Scene_Loader.onRestarted += ResetStats;
    }
}
