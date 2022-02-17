
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Image icon;
    Item item;


    public void AddItemUI(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.UseItem();
        }

    }
}
