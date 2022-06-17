using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Loader : MonoBehaviour
{
    public static bool hasLosed = false;
    public delegate void onRestart();
    public static event onRestart onRestarted;
    

    public static void RestartLevel()
    {
        hasLosed = false;
        onRestarted?.Invoke();
    }

    public static void ChangeBool(bool changeBool)
    {
        hasLosed = changeBool;
    }

}
