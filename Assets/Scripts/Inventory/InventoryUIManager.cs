using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 背包管理，将背包内容与UI显示同步
public class InventoryUIManager : MonoBehaviour
{
    // 背包界面
    public GameObject bag;
    // 背包网格
    public GameObject slotGrid;
    // 背包格子
    public Slot slotPrefab;
    // 背包UI显示状态
    bool bagDisplay;

    // 键盘测试
    public GameObject keyTest;

    // 单例模式
    static InventoryUIManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        bagDisplay = false;
    }

    private void Update()
    {
        KeyCheck();
        bag.SetActive(bagDisplay);
        keyTest.SetActive(!bagDisplay);
    }

    void KeyCheck()
    {
        //// 背包已经关闭的情况下，才能打开主菜单
        //if (!bagDisplay && Input.GetKeyDown(KeyCode.Escape))
        //{
        //    pauseMenuDisplay = !pauseMenuDisplay;
        //}
        //// 只有在没有打开暂停菜单的情况下，才能打开或关闭背包
        //if (!pauseMenuDisplay)
        //{
        //    // 按键盘上的I键打开或关闭背包，按ESC键关闭背包
        //    if (Input.GetKeyDown(KeyCode.I))
        //    {
        //        bagDisplay = !bagDisplay;
        //    }
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        bagDisplay = false;
        //    }
        //}
        // 按键盘上的I键打开或关闭背包，按ESC键关闭背包
        if (Input.GetKeyDown(KeyCode.I))
        {
            bagDisplay = !bagDisplay;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bagDisplay = false;
        }
    }

    // 在背包中创建新物品item（传入参数）,并且同步到UI
    public static void CreateNewItem(Item touchItem)
    {
        // Instantiate:在运行时实例化slotPrefab（预制件），即在slotGrid（背包网格）下创建一个slot子对象
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);

        // 指定该对象的父组件为slotGrid
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform,false);

        // 将item的物品信息赋值到实例化的slot中，UI显示出物品信息
        newItem.item = touchItem;
        newItem.slotImage.sprite = touchItem.itemImage;
    }
}
