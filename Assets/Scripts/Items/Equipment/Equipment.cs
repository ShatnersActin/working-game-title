using System.Text;
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
        if (rarityIndex == 1)
        {
            Debug.Log("Uncommon Item, one bonus");
            RandomStatRoll();
            return;
        }
        if(rarityIndex == 2)
        {
            Debug.Log("Rare Item, two bonuses");
            RandomStatRoll();
            RandomStatRoll();
            return;

        }
        if(rarityIndex == 3)
        {
            Debug.Log("Very Rare Item, three bonuses");
            RandomStatRoll();
            RandomStatRoll();
            RandomStatRoll();
            return;

        }


        void RandomStatRoll()
        {
            int randomStat = (int)Random.Range(0.0f, maxStatsIndex);
            statsIndex = randomStat;
            Debug.Log("Randoms Stat Index = " + statsIndex);

            if (statsIndex == 0)         //Str Roll
            {
                int randomStatValue = (int)Random.Range(1.0f, 3.0f);
                bonusStr = randomStatValue;
                Debug.Log("Item awarded " + bonusStr + " Bonus Strength!");
                //update Str
            }
            if (statsIndex == 1)         //Dex Roll
            {
                int randomStatValue = (int)Random.Range(1.0f, 3.0f);
                bonusDex = randomStatValue;
                Debug.Log("Item awarded " + bonusDex + " Bonus Dexterity!");
                //update Dex
            }
            if (statsIndex == 2)         //Con Roll
            {
                int randomStatValue = (int)Random.Range(1.0f, 3.0f);
                bonusCon = randomStatValue;
                Debug.Log("Item awarded " + bonusCon + " Bonus Constitution!");
                //update Con
            }
            if (statsIndex == 3)         //Int Roll
            {
                int randomStatValue = (int)Random.Range(1.0f, 3.0f);
                bonusInt = randomStatValue;
                Debug.Log("Item awarded " + bonusInt + " Bonus Intelligence!");
                //update Int
            }
        }
    }

    public override string GetToolTipInfoText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(itemRarity).AppendLine();
        if(bonusStr != 0)
        {
            builder.Append("Bonus Strength: ").Append(bonusStr).AppendLine();
        }
        if (bonusDex != 0)
        {
            builder.Append("Bonus Dexterity: ").Append(bonusDex).AppendLine();
        }
        if (bonusCon != 0)
        {
            builder.Append("Bonus Constitution: ").Append(bonusCon).AppendLine();
        }
        if (bonusInt != 0)
        {
            builder.Append("Bonus Intelligence: ").Append(bonusInt).AppendLine();
        }


        return builder.ToString();
    }

    public override string ColoredName
    {
        get
        {
            int rarityIndex = (int)itemRarity;
            Color textColor;
            string hexColor;

            if (rarityIndex == 0)
            {
                textColor = Color.white;                                //white
                hexColor = ColorUtility.ToHtmlStringRGB(textColor);
                return $"<color=#{hexColor}>{name}</color>";
            }
            if (rarityIndex == 1)
            {
                textColor = Color.green;                                //green
                hexColor = ColorUtility.ToHtmlStringRGB(textColor);
                return $"<color=#{hexColor}>{name}</color>";
            }
            if (rarityIndex == 2)
            {
                textColor = Color.blue;                                 //blue
                hexColor = ColorUtility.ToHtmlStringRGB(textColor);
                return $"<color=#{hexColor}>{name}</color>";
            }
            if (rarityIndex == 3)
            {
                textColor = Color.HSVToRGB(290f, 100f, 100f);           //purple
                hexColor = ColorUtility.ToHtmlStringRGB(textColor);
                return $"<color=#{hexColor}>{name}</color>";
            }
            return null;
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



