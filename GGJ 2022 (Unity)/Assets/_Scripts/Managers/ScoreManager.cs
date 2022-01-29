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
        var addScore = scoreAmount;

        switch (player)
        {
            case PlayerController.Player.FirstPlayer:
                ScoreFirstPlayer(addScore);
                break;

            case PlayerController.Player.SecondPlayer:
                ScoreSecondPlayer(addScore);
                break;

            default:

                break;
        }
    }

    public void EveryoneScore(float scoreAmount)
    {
        var addScore = scoreAmount;
        ScoreFirstPlayer(addScore);
        ScoreSecondPlayer(addScore);
    }

    private void ScoreFirstPlayer(float addScore)
    {
        _firstPlayer.ShowScore(addScore.ToString());
    }

    private void ScoreSecondPlayer(float addScore)
    {
        _secondPlayer.ShowScore(addScore.ToString());
    }

    public void ProportionalScore(int firstPlayerIngredients, int secondPlayerIngredients, float score)
    {
        float totalScore = (score / (firstPlayerIngredients + secondPlayerIngredients));
        float firstScore = totalScore * firstPlayerIngredients;
        float secondScore = totalScore * secondPlayerIngredients * 0.75f;

        ScoreFirstPlayer(firstScore);
        ScoreSecondPlayer(secondScore);
    }
}


    