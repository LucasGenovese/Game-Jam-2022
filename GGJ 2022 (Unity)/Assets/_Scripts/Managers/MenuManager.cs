using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnClickPlay()
    {
        GameManager.Instance.LevelLoader.LoadScene("Loading");
    }

    public void OnClickOptions()
    {
        GameManager.Instance.LevelLoader.LoadScene("Controls");
    }

    public void OnClickCredits()
    {
        GameManager.Instance.LevelLoader.LoadScene("Credits");
    }

    public void OnClickBack()
    {
        GameManager.Instance.LevelLoader.LoadScene("Menu");
    }

    public void OnClickExit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }
}
