using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text textTimer;

    private float timer = 151.0f; // 2:30 minutos
    private bool isTimer = false;

    void Update()
    {
        timer -= Time.deltaTime;
        DisplayTimer();

        if (timer < 0)
        {
            textTimer.text = "FIN";
        }
    }

    void DisplayTimer()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
