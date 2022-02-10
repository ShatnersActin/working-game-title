using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged OnEquipmentChangedCallback;

    private void Start()
    {
        inventory = Inventory.instance;
        int numSlots =  System.Enum.GetNames(typeof(Equipment.EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
        }

        //Send Event when Equipment is changed
        if(OnEquipmentChangedCallback != null)
        {
            OnEquipmentChangedCallback.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);

            //Send Event when Equipment is changed
            if (OnEquipmentChangedCallback != null)
            {
                OnEquipmentChangedCallback.Invoke(null, oldItem);
            }

            currentEquipment[slotIndex] = null;
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        //code for hotkeys/buttons/UI to perform Unequip actions
    }
}
