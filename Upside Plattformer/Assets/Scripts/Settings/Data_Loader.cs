using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Data_Loader : MonoBehaviour
{
    public int maxScore;
    private GyroTest player;
    [SerializeField] private TextMeshProUGUI maxScoreText;
    void Start()
    {
        player = FindObjectOfType<GyroTest>();
        if(!PlayerPrefs.HasKey("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore",0);

        }

        UpdateTextScore();        
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        maxScore = 0;
    }

    private void UpdateTextScore()
    {   Debug.Log(PlayerPrefs.GetInt("MaxScore"));
        maxScoreText.text = "Max Score: " + PlayerPrefs.GetInt("MaxScore");
    }

    void OnEnable()
    {
        Scene_Loader.onRestarted += UpdateTextScore;
    }
    private void OnDisable() 
    {
        Scene_Loader.onRestarted -= UpdateTextScore;    
    }

    public void Quit()
    {
        Application.Quit();
    }
}
