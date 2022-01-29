using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region # // Game Manager Instance \\ #
    // Game Manager Instance
    public static GameManager Instance;
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
}
