using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public Tooltip tooltip;
    public Image background;
    Item item;

    public void AddItemUI(Item newItem)
    {
        
        item = newItem;
        icon.sprite = item.icon;
        background.sprite = item.rarityColor;
        icon.enabled = true;

    }

    public void UseItem()
    {
        if (item != null)
        {
            item.UseItem();
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            tooltip.DisplayInfo(item);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item != null)
        {
            tooltip.HideInfo();
        }

    }
}
