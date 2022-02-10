using System;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public int id;
    new public string name = "Default Item";
    public Sprite icon;       
    
    public virtual void UseItem()
    {
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this);
    }

}

/*
[System.Serializable]
public class ItemBuff
{
    public Attribute attribute;
    public int value;
    public int maxValue;
    public int minValue;

    public ItemBuff(int min, int max)
    {
        min = minValue;
        max = maxValue;
        RandomRoll();
    }

    public void RandomRoll()
    {
        value = UnityEngine.Random.Range(minValue, maxValue);
    }

}

[Serializable]
public class ItemObject
{
    public string Name;
    public int id;
    public ItemBuff[] buffs;
    public ItemObject(Item item)
    {
        Name = item.name;
        id = item.id;
        buffs = new ItemBuff[item.buffs.Length];

        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].minValue, item.buffs[i].maxValue);
            buffs[i].attribute = item.buffs[i].attribute;
        }
    }
}

public enum Attribute
{
    Strength,
    Constitution,
    Dexterity,
    Intelligence
}
*/

