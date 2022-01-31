using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnInvetoryChanged();
    public OnInvetoryChanged onInvetoryChangedCallback;

    public int space = 60;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Inventory Full");
            return false;
        }
        items.Add(item);
        if (onInvetoryChangedCallback != null)
        {
            onInvetoryChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);
        if (onInvetoryChangedCallback != null)
        {
            onInvetoryChangedCallback.Invoke();
        }
    }
    
}
