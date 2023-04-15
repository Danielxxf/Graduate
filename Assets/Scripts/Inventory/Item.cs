using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 继承ScriptableObject类，再通过CreateAssetMenu，在菜单中新建一个选项，
// 能够在游戏为运行前创建并“实例化”该Item类定义的数据结构，从而能够存储一个物品固定的信息
// 将类定义的数据结构在游戏开始前就能“实例化”并赋值
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    //定义游戏里一个物品的数据结构

    //物品ID，每一个物品对应单个唯一的ID
    public int itemID;
    //物品名称
    public string itemName;
    //物品对应的显示图片
    public Sprite itemImage;
    [TextArea]
    public string itemInfo;
}
