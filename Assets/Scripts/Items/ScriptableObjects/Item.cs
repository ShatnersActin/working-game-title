using System;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public int id;
    new public string name = "Default Item";
    public Sprite icon;
    public Sprite rarityColor;

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

    public abstract string GetToolTipInfoText();
    public abstract string ColoredName { get; }
}


