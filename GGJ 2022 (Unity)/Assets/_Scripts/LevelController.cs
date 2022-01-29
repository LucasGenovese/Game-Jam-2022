using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Online Settings")]
    [SerializeField] private Transform _firstPlayerSpawn;
    [SerializeField] private Transform _secondPlayerSpawn;
    [SerializeField] private bool _playerExists;

    [Header("Extras")]
    [SerializeField] private IngredientDatabase _ingredientDatabase;
    [SerializeField] private ScoreManager _scoreManager;

    public IngredientDatabase IngredientDatabase => _ingredientDatabase;
    public ScoreManager ScoreManager => _scoreManager;

    public void OnlinePlayerSelection(GameObject player)
    {
        if (!_playerExists)
        {
            player.transform.position = _firstPlayerSpawn.position;
            player.GetComponent<PlayerController>().PlayerType = PlayerController.Player.FirstPlayer;
            _playerExists = true;
        }

        else
        {
            player.transform.position = _secondPlayerSpawn.position;
            player.GetComponent<PlayerController>().PlayerType = PlayerController.Player.SecondPlayer;
        }
    }

}
