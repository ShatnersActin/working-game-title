using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> items = new List<Item>();

    public int space;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool AddItem(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Inventory Full");
            return false;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;

    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
