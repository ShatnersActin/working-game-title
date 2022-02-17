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

    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void GenerateStats()
    {
        
    }
}


