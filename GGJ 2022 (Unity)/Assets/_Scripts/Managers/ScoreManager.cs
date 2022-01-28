using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Scores")] 
    [SerializeField] private float _player1OverallScore;
    [SerializeField] private float _player2OverallScore;

    [Header("Components")]
    [SerializeField] private PlayerScore _firstPlayer;
    [SerializeField] private PlayerScore _secondPlayer;

    float score;

    public void PlayerScore(PlayerController.Player player, float scoreAmount)
    {
        score = scoreAmount;

        switch (player)
        {
            case PlayerController.Player.FirstPlayer:
                ScoreFirstPlayer();
                break;

            case PlayerController.Player.SecondPlayer:
                ScoreSecondPlayer();
                break;

            default:

                break;
        }
    }

    private void ScoreFirstPlayer()
    {
        _firstPlayer.ShowScore(score.ToString());
    }

    private void ScoreSecondPlayer()
    {
        _secondPlayer.ShowScore(score.ToString());
    }
}


    