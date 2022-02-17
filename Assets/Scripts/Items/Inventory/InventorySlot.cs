
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class InventorySlot : NetworkBehaviour
{
    public Image icon;
    public Button removeButton;
    Item item;
    EquipmentManager equipmentManager;
    Inventory inventory;

    public void Awake()
    {
        inventory = gameObject.GetComponentInParent<Inventory>();
        equipmentManager = gameObject.GetComponentInParent<EquipmentManager>();
    }

    public void AddItemUI(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void RemoveItemUI()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        gameObject.GetComponentInParent<Inventory>().RemoveItem(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            //item.UseItem();
            equipmentManager.Equip((Equipment)item);
            inventory.RemoveItem(item);
        }
    }
}
