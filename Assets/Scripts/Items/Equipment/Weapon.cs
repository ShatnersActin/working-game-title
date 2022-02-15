using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : Equipment
{
    public float weaponSpeed;
    public float weaponRange;
    public int weaponDamage;

    public enum WeaponType
    {
        SwordNShield,   //index 0
        BattleAxe,      //index 1
        Daggers,        //index 2
        Staff,          //index 3
        Bow             //index 4
    }


}
