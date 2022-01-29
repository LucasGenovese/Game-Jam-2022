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

    }

    public void OnClickCredits()
    {

    }

    public void OnClickBack()
    {

    }

    public void OnClickExit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }
}
