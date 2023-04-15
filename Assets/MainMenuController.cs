using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void Begin()
    {
        GameProcessController.GameBegin();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
