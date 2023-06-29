using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameActions: MonoBehaviour
{
    public static void Exit()
    {
        Application.Quit();
    }

    public static void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void GoLevels()
    {
        SceneManager.LoadScene(1);
    }

    public static void GoGame(int level)
    {
        DataSingleton.Instance.Level = level;
        SceneManager.LoadScene(2);
    }

}
