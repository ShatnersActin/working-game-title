using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemsParent;
    Inventory inventory;
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = gameObject.GetComponentInParent<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItemUI(inventory.items[i]);
            }else
            {
                slots[i].RemoveItemUI();
            }
        }
    }
}
