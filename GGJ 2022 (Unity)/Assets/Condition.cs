using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Condition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _firstPlayerScore;
    [SerializeField] private TextMeshProUGUI _secondPlayerScore;

    public void Show(float firstPlayer, float secondPlayer)
    {
        _firstPlayerScore.text = firstPlayer.ToString();
        _secondPlayerScore.text = secondPlayer.ToString();
        this.gameObject.SetActive(true);
    }
}
