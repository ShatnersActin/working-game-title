
using UnityEngine.EventSystems;
using Unity.Netcode;
using UnityEngine.UI;

public class InventorySlot : NetworkBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public Image background;
    public Button removeButton;
    public Tooltip tooltip;
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
        background.sprite = item.rarityColor;
        icon.enabled = true;
        background.enabled = true;
        removeButton.interactable = true;
    }

    public void RemoveItemUI()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        background.sprite = null;
        background.enabled = false;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null)
        {
            tooltip.DisplayInfo(item);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(item != null)
        {
            tooltip.HideInfo();
        }
        
    }
}
