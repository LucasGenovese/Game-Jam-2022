using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Scores")] 
    [SerializeField] private float _player1OverallScore;
    [SerializeField] private float _player2OverallScore;
    [SerializeField] private TextMeshProUGUI _overallScore1;
    [SerializeField] private TextMeshProUGUI _overallScore2;

    [Header("Components")]
    [SerializeField] private PlayerScore _firstPlayer;
    [SerializeField] private PlayerScore _secondPlayer;

    float score;

    public void StorePlayersScores()
    {
        GameManager.Instance.StorePlayersScores(_player1OverallScore, _player2OverallScore);   
    }

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
        _player1OverallScore = _player1OverallScore + addScore;
        _overallScore1.text = _player1OverallScore.ToString();
        _firstPlayer.ShowScore(addScore.ToString());
    }

    private void ScoreSecondPlayer(float addScore)
    {
        _player2OverallScore = _player2OverallScore + addScore;
        _overallScore2.text = _player2OverallScore.ToString();
        _secondPlayer.ShowScore(addScore.ToString());
    }

    public void ProportionalScore(int firstPlayerIngredients, int secondPlayerIngredients, float score)
    {
        float totalScore = (score / (firstPlayerIngredients + secondPlayerIngredients));
        float firstScore = totalScore * firstPlayerIngredients;
        float secondScore = totalScore * secondPlayerIngredients * 0.75f;

        if (firstScore > 0)
        {
            ScoreFirstPlayer(firstScore);
        }

        if (secondScore > 0)
        {
            ScoreSecondPlayer(secondScore);
        }
    }
}


    