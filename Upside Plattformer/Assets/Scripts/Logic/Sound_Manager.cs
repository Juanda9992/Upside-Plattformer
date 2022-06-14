using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public static Sound_Manager soundManager;

    private static AudioSource source; 
    private static AudioClip lose,point;


    // Start is called before the first frame update
    void Start()
    {
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
}
