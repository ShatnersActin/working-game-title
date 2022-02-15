using UnityEngine;

public class DropLoot : MonoBehaviour
{
    Inventory inventory;
    Database database;
    Equipment itemDrop;


    public void GenerateLoot()
    {
        inventory = Inventory.instance;
        database = Database.instance;
        itemDrop = (Equipment)database.GetRandomItem();
        Equipment itemCopy = (Equipment)itemDrop.GetCopy();
        Debug.Log("Generated Loot = " + itemCopy.name);
        itemCopy.GenerateStats();
        inventory.AddItem(itemCopy);
    }

}
