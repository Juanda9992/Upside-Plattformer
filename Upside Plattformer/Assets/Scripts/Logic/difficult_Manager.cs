using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficult_Manager : MonoBehaviour
{   
    public delegate void onDead();
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            onDeath();
        }
    }

    private void onDeath()
    {
        Sound_Manager.PlaySound("lose");
        Scene_Loader.hasLosed = true;
        Scene_Loader.RestartLevel();
    }

}
