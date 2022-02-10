using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public ItemBuff[] Buffs;

    public override void UseItem()
    {
        base.UseItem();

        //Equip Item
        EquipmentManager.instance.Equip(this);

        //Remove from Inventory
        RemoveFromInventory();
    }

    public enum EquipmentSlot
    {
        Head,    //index 0
        Chest,   //index 1
        Legs,    //index 2
        Feet,    //index 3
        Weapon   //index 4
    }
}

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

public enum Attribute
{
    Strength,
    Dexterity,
    Constitution,
    Intelligence
}



