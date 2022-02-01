using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkHealth : NetworkBehaviour
{
    public NetworkVariable<int> playerCurrentHealth = new NetworkVariable<int>();
    public NetworkVariable<int> playerMaxHealth = new NetworkVariable<int>();

    int conBonusHealth;
    int playerBaseHealth = 20;
    int _playerMaxHealth;

    void Start()
    {
        //Recalculate Player Max Health on Spawn
        NetworkPlayerStats networkPlayerStats = gameObject.GetComponent<NetworkPlayerStats>();
        networkPlayerStats.CalculateMaxHealth();
        base.OnNetworkSpawn();
    }


    //Function to set Current Health to Max Health
    [ServerRpc]
    public void CalulateMaxHealthServerRpc()
    {
        _playerMaxHealth = playerBaseHealth + ConBonusHealth();
        playerMaxHealth.Value = _playerMaxHealth;
        playerCurrentHealth.Value = playerMaxHealth.Value;
    }


    //Set Con Bonus Health based on amount of Player Consitiution
    public int ConBonusHealth()
    {
        int playerConValue = gameObject.GetComponent<ClientPlayerStats>().playerCon.Value;

        if (playerConValue <= 11)
        {
            conBonusHealth = 0;
        }
        if (playerConValue >= 12 && playerConValue <= 13)
        {
            conBonusHealth = 1;
        }
        if (playerConValue >= 14 && playerConValue <= 15)
        {
            conBonusHealth = 2;
        }
        if (playerConValue >= 16 && playerConValue <= 17)
        {
            conBonusHealth = 3;
        }
        if (playerConValue >= 18 && playerConValue <= 19)
        {
            conBonusHealth = 4;
        }
        if (playerConValue >= 20 && playerConValue <= 21)
        {
            conBonusHealth = 5;
        }
        if (playerConValue >= 22 && playerConValue <= 23)
        {
            conBonusHealth = 6;
        }
        if (playerConValue >= 24 && playerConValue <= 25)
        {
            conBonusHealth = 7;
        }
        if (playerConValue >= 26 && playerConValue <= 27)
        {
            conBonusHealth = 8;
        }
        if (playerConValue >= 28 && playerConValue <= 29)
        {
            conBonusHealth = 9;
        }
        if (playerConValue >= 30)
        {
            conBonusHealth = 10;
        }

        return conBonusHealth;
    }
}
