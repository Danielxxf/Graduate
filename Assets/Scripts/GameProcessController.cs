using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProcessController : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(0);
    }

    public static void GameBegin()
    {
        SceneManager.LoadScene(1);
    }

    public static void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void GamePass()
    {
        SceneManager.LoadScene(3);
    }
}
