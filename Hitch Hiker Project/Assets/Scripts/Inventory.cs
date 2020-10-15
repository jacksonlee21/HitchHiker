using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        Additem(new Item { itemType = Item.ItemType.Money, amount = 4 });
        Additem(new Item { itemType = Item.ItemType.Beer, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void Additem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}