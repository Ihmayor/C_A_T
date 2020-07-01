using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHanlder : MonoBehaviour
{
    public void PauseTime()
    {
        Time.timeScale = 0.0f;
    }

    public void UnPauseTime()
    {
        Time.timeScale = 1.0f;
    }


}
