using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text textTimer;

    private float timer = 10.0f; // 2:30 minutos 151
    private bool isTimer = false;

    void Update()
    {
        timer -= Time.deltaTime;
        DisplayTimer();

        if (timer <= 0)
        {
            LevelController.Instance.ScoreManager.StorePlayersScores();
            GameManager.Instance.LevelLoader.LoadScene("Condition");
        }
    }

    void DisplayTimer()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
