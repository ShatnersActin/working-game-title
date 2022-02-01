using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ClientPlayerStats : NetworkBehaviour
{
    /// <summary>
    /// Class that holds all ServerRpc (Client to update Server) calls for Player Stats.  
    /// Used for Equipment stat bonuses, buffs, debuffs, max Health, and current health.
    /// </summary>
    /// 
    public NetworkVariable<int> playerStr = new NetworkVariable<int>();
    public NetworkVariable<int> playerDex = new NetworkVariable<int>();
    public NetworkVariable<int> playerCon = new NetworkVariable<int>();
    public NetworkVariable<int> playerInt = new NetworkVariable<int>();
    public NetworkVariable<int> playerHealth = new NetworkVariable<int>();
    public NetworkVariable<int> playerMaxHealth = new NetworkVariable<int>();

    [SerializeField]
    int baseHealth = 20;
    [SerializeField]
    int conBonusHealth;

    [ServerRpc]
    public void UpdateStrServerRpc()
    {
        //logic to increase or decrease playerStr
    }

    [ServerRpc]
    public void UpdateConServerRpc()
    {
        //logic to increase or decrease playerCon.  Test function below
        playerCon.Value++;
    }

    [ServerRpc]
    public void UpdateDexServerRpc()
    {
        //logic to increase or decrease playerDex
    }

    [ServerRpc]
    public void UpdateIntServerRpc()
    {
        //logic to increase or decrease playerInt
    }

    [ServerRpc]
    public void UpdatePlayerHealthServerRpc()
    {
        //logic to increase or decrease playerHealth
    }

    public void CalculatePlayerMaxHealth()
    {
        //set Max Player Health to Base Health plus Constitution Health Bonus
        playerMaxHealth.Value = baseHealth + ConBonusHealth();
    }

    public int ConBonusHealth()
    {

        if(playerCon.Value <= 11)
        {
            conBonusHealth = 0;
        }
        if (playerCon.Value >= 12 && playerCon.Value <= 13)
        {
            conBonusHealth = 1;
        }
        if (playerCon.Value >= 14 && playerCon.Value <= 15)
        {
            conBonusHealth = 2;
        }
        if (playerCon.Value >= 16 && playerCon.Value <= 17)
        {
            conBonusHealth = 3;
        }
        if (playerCon.Value >= 18 && playerCon.Value <= 19)
        {
            conBonusHealth = 4;
        }
        if (playerCon.Value >= 20 && playerCon.Value <= 21)
        {
            conBonusHealth = 5;
        }
        if (playerCon.Value >= 22 && playerCon.Value <= 23)
        {
            conBonusHealth = 6;
        }
        if (playerCon.Value >= 24 && playerCon.Value <= 25)
        {
            conBonusHealth = 7;
        }
        if (playerCon.Value >= 26 && playerCon.Value <= 27)
        {
            conBonusHealth = 8;
        }
        if (playerCon.Value >= 28 && playerCon.Value <= 29)
        {
            conBonusHealth = 9;
        }
        if (playerCon.Value >= 30)
        {
            conBonusHealth = 10;
        }

        return conBonusHealth;
    }
}
