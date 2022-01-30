using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ConditionManager : MonoBehaviour
{
    [SerializeField] private Condition firstPlayerWin;
    [SerializeField] private Condition secondPlayerWin;
    [SerializeField] private Condition drawImage;

    private void Start()
    {
        LoadConditionImage();
    }

    public void OnClickMenu()
    {
        GameManager.Instance.LevelLoader.LoadScene("Menu");
        PhotonNetwork.Disconnect();
    }

    public void LoadConditionImage()
    {
        if (GameManager.Instance.FirstPlayerScore > GameManager.Instance.SecondPlayerScore) // First Player Wins.
        {
            firstPlayerWin.Show(GameManager.Instance.FirstPlayerScore, GameManager.Instance.SecondPlayerScore);
        }

        if (GameManager.Instance.SecondPlayerScore > GameManager.Instance.FirstPlayerScore) // Second Player Wins.
        {
            secondPlayerWin.Show(GameManager.Instance.FirstPlayerScore, GameManager.Instance.SecondPlayerScore);
        }

        if (GameManager.Instance.SecondPlayerScore == GameManager.Instance.FirstPlayerScore) // Draw.
        {
            drawImage.Show(GameManager.Instance.FirstPlayerScore, GameManager.Instance.SecondPlayerScore);
        }
    }


}
