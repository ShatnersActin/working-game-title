using UnityEngine;
using Unity.Netcode;

public class DropLoot : NetworkBehaviour
{
    Inventory inventory;
    Database database;
    Equipment itemDrop;


    public void GenerateLoot()
    {
        inventory = gameObject.GetComponentInParent<Inventory>();
        database = Database.instance;
        itemDrop = (Equipment)database.GetRandomItem();
        Equipment itemCopy = (Equipment)itemDrop.GetCopy();
        Debug.Log("Generated Loot = " + itemCopy.name);
        itemCopy.GenerateStats();
        inventory.AddItem(itemCopy);
        
    }

}
