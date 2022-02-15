using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public GameObject itemsParent;
    Inventory inventory;
    EquipmentManager equipmentManager;
    Equipment[] uiCurrentEquipment;
    EquipmentSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        equipmentManager = EquipmentManager.instance;
        inventory = Inventory.instance;

        equipmentManager.OnEquipCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    void UpdateUI()
    {

        for (int i = 0; i < equipmentManager.currentEquipment.Length; i++)
        {
            if (i < slots.Length && equipmentManager.currentEquipment[i] != null)
            {
                slots[i].AddItemUI(equipmentManager.currentEquipment[i]);
            }
            else
            {
                slots[i].RemoveItemUI();
            }
            
        }

    }
}
