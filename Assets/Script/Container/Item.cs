using UnityEngine;
public class Item
{
    public string itemName;     // 物品名称
    public Sprite itemSprite;   // 物品图标
    public string itemInfo;     // 物品描述
    public int itemType;        // 物品类型：0固体，1液体，2气体、
    public int itemStack;       // 物品可堆叠数量

}

public class ItemObject
{
    public Item itemObject;// 物品类别
    public int itemHeld;        // 物品数量
}