using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageInventory : MonoBehaviour
{
    public Item item;
    private Inventory inventory;

    public void FindInventoryObject()
    {
        inventory = gameObject.GetComponent<Inventory>();
        Debug.Log("Found Inventory");
    }

    public void AddItemToInventory()
    {
        inventory = Inventory.instance;
        inventory.AddItem(item);
    }

    public void RemoveItemFromInventory()
    {
        inventory = Inventory.instance;
        inventory.RemoveItem(item);
    }

}
