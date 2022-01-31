using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Item : ScriptableObject
{
    public string weaponName = "New Weapon";
    public Sprite icon = null;
    public bool isDefaultWeapon = false;


}
