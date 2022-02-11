using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public ItemRarityEnum itemRarity;
    public StatsEnum stats;

    //Starting Stat Values
    public int bonusStr;
    public int bonusDex;
    public int bonusCon;
    public int bonusInt;

    public override void UseItem()
    {
        base.UseItem();

        //Equip Item
        EquipmentManager.instance.Equip(this);

        //Remove from Inventory
        RemoveFromInventory();
    }

    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void GenerateStats()
    {
        //Do stuff to generate stats based on rarity

        int rarityIndex = (int)itemRarity;
        int statsIndex = (int)stats;

        int maxRarityIndex = System.Enum.GetNames(typeof(ItemRarityEnum)).Length;
        int maxStatsIndex = System.Enum.GetNames(typeof(StatsEnum)).Length;


        if (rarityIndex == 0)
        {
            Debug.Log("Common Item, no Bonus");
            return;
        }
        if(rarityIndex == 1)
        {
            Debug.Log("Uncommon Item, one bonus");
            int randomStat = (int)Random.Range(0.0f, maxStatsIndex);
            statsIndex = randomStat;
            Debug.Log("Randoms Stat Index = " + statsIndex);


            if(statsIndex == 0)         //Str Roll
            {
                int randomStatValue = (int)Random.Range(1.0f, 3.0f);
                bonusStr = randomStatValue;
                Debug.Log("Item awarded " + bonusStr + " Bonus Strength!");
                //update Str
            }
            if(statsIndex == 1)         //Dex Roll
            {
                int randomStatValue = (int)Random.Range(1.0f, 3.0f);
                bonusDex = randomStatValue;
                Debug.Log("Item awarded " + bonusDex + " Bonus Dexterity!");
                //update Dex
            }
            if(statsIndex == 2)         //Con Roll
            {
                int randomStatValue = (int)Random.Range(1.0f, 3.0f);
                bonusCon = randomStatValue;
                Debug.Log("Item awarded " + bonusCon + " Bonus Constitution!");
                //update Con
            }
            if(statsIndex == 3)         //Int Roll
            {
                int randomStatValue = (int)Random.Range(1.0f, 3.0f);
                bonusInt = randomStatValue;
                Debug.Log("Item awarded " + bonusInt + " Bonus Intelligence!");
                //update Int
            }


            return;
        }
        if(rarityIndex == 2)
        {
            Debug.Log("Rare Item, two bonuses");
            return;
        }
        if(rarityIndex == 3)
        {
            Debug.Log("Very Rare Item, three bonuses");
            return;
        }
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



