using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    private GyroTest player;
    public static Sound_Manager soundManager;

    public static AudioSource source; 
    private static AudioClip lose,point;


    // Start is called before the first frame update
    void Start()
    {
        GyroTest.onScored += PitchAudio;
        player = GameObject.FindObjectOfType<GyroTest>();
        point = Resources.Load<AudioClip>("Point");
        lose = Resources.Load<AudioClip>("Lose");
        soundManager = this;
        source = GetComponent<AudioSource>();
    }

    public static void PlaySound(string name)
    {
        switch(name)
        {
            case  "lose":
            source.PlayOneShot(lose);
            break;

            case "point":
            source.PlayOneShot(point);
            break;

            default:
            break;
        }
    }

    public void PitchAudio()
    {
        float pitch = player.pointsInARow /10;
        Debug.Log(player.pointsInARow / 10);
        if(player.pointsInARow >= 1)
        {
            
            source.pitch = (player.pointsInARow / 10) + 1;
        }
        else
        {
            source.pitch = 1;
        }
        
    }
}
