using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//背包类，挂载在Player对象上，当游戏开始，随着Player对象的实例化而实例化
public class Inventory : MonoBehaviour

{
    // 背包数据结构
    // 定义一个容纳Item类型的列表
    public List<Item> itemList = new List<Item>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            Item touchItem = collision.GetComponent<ItemOnWorld>().config;
            PickUpItem(touchItem);
            // 销毁在地图上的物品，即本组件对应的GameObject
            Destroy(collision.gameObject);
        }
    }

    void PickUpItem(Item touchItem)
    {
        itemList.Add(touchItem);
        InventoryUIManager.CreateNewItem(touchItem);
    }
}
