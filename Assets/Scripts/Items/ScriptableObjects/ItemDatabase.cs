using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDB", menuName = "Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> allItems;
}
