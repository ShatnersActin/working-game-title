using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageInventory : MonoBehaviour
{
    #region Singleton
    public static ManageInventory instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Item item;
    private Inventory inventory;

    public void FindInventoryObject()
    {
        inventory = gameObject.GetComponent<Inventory>();
        Debug.Log("Found Inventory");
    }

    public void AddItemToInventory()
    {
        inventory = gameObject.GetComponent<Inventory>();
        inventory.AddItem(item);
    }

    public void RemoveItemFromInventory()
    {
        inventory = gameObject.GetComponent<Inventory>();
        inventory.RemoveItem(item);
    }

}
