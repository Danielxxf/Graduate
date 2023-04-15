using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    public void reStart()
    {
        GameProcessController.GameBegin();
    }
    public void Back()
    {
        GameProcessController.BackToMenu();
    }
}
