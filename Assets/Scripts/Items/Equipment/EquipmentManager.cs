using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class EquipmentManager : NetworkBehaviour
{
    
    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Equipment[] currentEquipment;
    Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged OnEquipmentChangedCallback;

    public delegate void OnEquip();
    public OnEquip OnEquipCallback;

    private void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
        int numSlots =  System.Enum.GetNames(typeof(Equipment.EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        if(IsClient && IsOwner)
        {
            int slotIndex = (int)newItem.equipSlot;

            Equipment oldItem = null;

            if (currentEquipment[slotIndex] != null)
            {
                oldItem = currentEquipment[slotIndex];
                inventory.AddItem(oldItem);
            }

            //Send Event when Equipment is changed
            if (OnEquipmentChangedCallback != null)
            {
                OnEquipmentChangedCallback.Invoke(newItem, oldItem);
            }

            currentEquipment[slotIndex] = newItem;
            OnEquipCallback.Invoke();
        }

    }

    public void Unequip(int slotIndex)
    {
        if(IsClient && IsOwner)
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
                OnEquipCallback.Invoke();
            }
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
