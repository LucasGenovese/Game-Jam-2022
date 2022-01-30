using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public void OnClickLocalMultiplayer()
    {
        GameManager.Instance.MusicGame();
        GameManager.Instance.LevelLoader.LoadScene("Game-Local");
    }
}
