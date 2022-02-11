using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    Inventory inventory;
    public Equipment itemDrop;

    public void GenerateLoot()
    {
        inventory = Inventory.instance;
        Equipment itemCopy = (Equipment)itemDrop.GetCopy();
        Debug.Log("Generated Loot = " + itemCopy.name);
        itemCopy.GenerateStats();
        inventory.AddItem(itemCopy);
    }

}
