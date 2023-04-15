using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // 定义一个背包物品格的数据结构
    // 物品对应的Item对象
    public Item item;
    // 物品图片，实时更新物品图片
    public Image slotImage;
    private Text slotName;
    private Text slotInfo;


    PlayerInfo playerInfo;

    public Button useBtn;
    public Button deleteBtn;
    Button self;
    GameObject itemMenu;

    void Start()
    {
        slotName = GameObject.Find("ItemName").GetComponent<Text>();
        slotInfo = GameObject.Find("ItemInfo").GetComponent<Text>();
        // 引用传递
        playerInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        self = GetComponent<Button>();
        //定义一个私有方法OnClick(),并在Start()方法里为Button添加点击事件的监听，作为参数传入OnClick方法
        self.onClick.AddListener(Menu);
        useBtn.onClick.AddListener(UseItem);
        deleteBtn.onClick.AddListener(deleteSelf);
        itemMenu = transform.Find("itemMenu").gameObject;
    }

    void UseItem()
    {
        switch (item.itemID)
        {
            case 1001:
                // 回复5点血量
                playerInfo.IncOrDecHP(5);
                break;
            case 1002:
                playerInfo.IncOrDecHP(8);
                break;
        }
        // 使用后销毁
        Destroy(gameObject);
    }

    // 物品处理菜单
    void Menu()
    {
        itemMenu.SetActive(!itemMenu.activeSelf);
        slotName.text = itemMenu.activeSelf ? item.itemName : "";
        slotInfo.text = itemMenu.activeSelf ? item.itemInfo : "";
    }

    // 丢弃物品（销毁自身）
    void deleteSelf()
    {
        Destroy(gameObject);
    }
}
