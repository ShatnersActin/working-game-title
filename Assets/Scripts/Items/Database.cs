using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
   #region Singleton
    public static Database instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public ItemDatabase items;
    
    public static Item GetItemByID(int ID)
    {
        foreach (Item item in instance.items.allItems)
        {
            if(item.id == ID)
            {
                return item;
            }
        }
        return null;
    }

    public Item GetRandomItem()
    {
        return instance.items.allItems[Random.Range(0, instance.items.allItems.Count)];
    }


}
