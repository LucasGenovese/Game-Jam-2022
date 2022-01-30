using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text textTimer;

    [SerializeField] private float timer = 151f; // 2:30 minutos 151
    private bool isTimer = false;

    void Update()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        if (timer <= 0)
        {
            textTimer.text = string.Format("0:00");
            LevelController.Instance.ScoreManager.StorePlayersScores();
            GameManager.Instance.FinishMusic();
            GameManager.Instance.LevelLoader.LoadScene("Condition");
        }

        else
        {
            textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);            
        }
    }
}
