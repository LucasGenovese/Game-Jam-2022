using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region # // Game Manager Instance \\ #
    // Game Manager Instance
    public static GameManager Instance;


    public bool playerOnline = false;

    [SerializeField] private float _firstPlayerScore;
    [SerializeField] private float _secondPlayerScore;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    #endregion // GameManager Instance

    [SerializeField] private LevelLoader _levelLoader;

    public LevelLoader LevelLoader
    {
        get { return _levelLoader; }
        set { _levelLoader = value; }
    }

    public void StorePlayersScores(float firstPlayer, float secondPlayer)
    {
        _firstPlayerScore = firstPlayer;
        _secondPlayerScore = secondPlayer;
    }


    public float FirstPlayerScore
    {
        get { return _firstPlayerScore; }
    }

    public float SecondPlayerScore
    {
        get { return _secondPlayerScore; }
    }
}
