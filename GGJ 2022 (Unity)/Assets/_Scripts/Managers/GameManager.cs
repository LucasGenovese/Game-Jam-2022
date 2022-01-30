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

    [Header("Core Manager")]
    [SerializeField] private LevelLoader _levelLoader;

    [Header("Music")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private AudioClip _finishMusic;
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

    public void MusicMenu()
    {
        _musicSource.Stop();
        _musicSource.clip = _menuMusic;
        _musicSource.volume = 0.2f;
        _musicSource.Play();
    }
    public void MusicGame()
    {
        _musicSource.Stop();
        _musicSource.clip = _gameMusic;
        _musicSource.volume = 0.02f;
        _musicSource.Play();
    }
    public void FinishMusic()
    {
        _musicSource.Stop();
        _musicSource.clip = _finishMusic;
        _musicSource.volume = 0.1f;
        _musicSource.Play();
    }
}
