using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 负责PlayerInfo和UI显示之间的同步
public class MenuUIManager : MonoBehaviour
{
    // 暂停菜单
    public GameObject pauseMenu;

    public Button continueBtn;
    public Button backBtn;

    // 各UI组件暂停菜单的显示状态
    bool pauseMenuDisplay;

    void Start()
    {
        // 启动游戏时，暂停菜单默认不显示
        pauseMenuDisplay = false;
        continueBtn.onClick.AddListener(Continue);
        backBtn.onClick.AddListener(Back);
    }

    // Update函数每一帧调用一次
    void Update()
    {
        KeyCheck();
        UpdateUI();
    }

    void Continue()
    {
        pauseMenuDisplay = false;
    }

    void Back()
    {
        GameProcessController.BackToMenu();
    }

    // 检测按键
    void KeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuDisplay = !pauseMenuDisplay;
        }
    }

    // 根据各UI组件显示状态的布尔变量更新UI显示
    void UpdateUI()
    {
        // 暂停菜单
        pauseMenu.SetActive(pauseMenuDisplay);
    }
}
