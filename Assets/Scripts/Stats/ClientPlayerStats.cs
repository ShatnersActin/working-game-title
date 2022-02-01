using System;
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

    //Events to grab when playerCon is changed in game and to update Player Max Health
    void OnEnable()
    {
        playerCon.OnValueChanged += conValueChanged;
    }

    private void OnDisable()
    {
        playerCon.OnValueChanged -= conValueChanged;
    }

    void conValueChanged(int oldValue, int newValue)
    {
        if(oldValue != newValue)
        {
            Debug.Log("playerCon went from " + oldValue + " to " + newValue);
            NetworkPlayerStats networkPlayerStats = gameObject.GetComponent<NetworkPlayerStats>();
            networkPlayerStats.CalculateMaxHealth();
        }
    }

    //Start ServerRPC Call Block

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

}
