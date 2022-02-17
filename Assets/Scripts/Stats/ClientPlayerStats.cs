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

    int statValue;

    int oldLocalPlayerStr;
    int newLocalPlayerStr;
    int strModifier;

    int oldLocalPlayerDex;
    int newLocalPlayerDex;
    int dexModifier;

    int oldLocalPlayerCon;
    int newLocalPlayerCon;
    int conModifier;

    int oldLocalPlayerInt;
    int newLocalPlayerInt;
    int intModifier;

    EquipmentManager equipmentManager;
    NetworkPlayerStats networkPlayerStats;

    private void Start()
    {
        equipmentManager = gameObject.GetComponent<EquipmentManager>();
        equipmentManager.OnEquipmentChangedCallback += OnEquipmentChanged;

        networkPlayerStats = gameObject.GetComponent<NetworkPlayerStats>();
    }

    //Events to grab when playerCon is changed in game and to update Player Max Health
    void OnEnable()
    {
        playerStr.OnValueChanged += strValueChanged;
        playerDex.OnValueChanged += dexValueChanged;
        playerCon.OnValueChanged += conValueChanged;
        playerInt.OnValueChanged += intValueChanged;
    }

    private void OnDisable()
    {
        playerStr.OnValueChanged -= strValueChanged;
        playerDex.OnValueChanged -= dexValueChanged;
        playerCon.OnValueChanged -= conValueChanged;
        playerInt.OnValueChanged -= intValueChanged;
    }

    void strValueChanged(int oldValue, int newValue)
    {
        if (oldValue != newValue)
        {
            Debug.Log("playerStr went from " + oldValue + " to " + newValue);
        }
    }

    void dexValueChanged(int oldValue, int newValue)
    {
        if (oldValue != newValue)
        {
            Debug.Log("playerDex went from " + oldValue + " to " + newValue);
        }
    }

    void conValueChanged(int oldValue, int newValue)
    {
        if(oldValue != newValue)
        {
            Debug.Log("playerCon went from " + oldValue + " to " + newValue);
            networkPlayerStats.CalculateMaxHealth();
        }
    }

    void intValueChanged(int oldValue, int newValue)
    {
        if (oldValue != newValue)
        {
            Debug.Log("playerInt went from " + oldValue + " to " + newValue);
        }
    }

    //Start ServerRPC Call Block

    [ServerRpc]
    public void UpdateStrServerRpc()
    {
        //logic to increase or decrease playerStr
        playerStr.Value = newLocalPlayerStr;
    }

    [ServerRpc]
    public void UpdateConServerRpc()
    {
        //logic to increase or decrease playerCon.  Test function below
        playerCon.Value = newLocalPlayerCon;
    }

    [ServerRpc]
    public void UpdateDexServerRpc()
    {
        //logic to increase or decrease playerDex
        playerDex.Value = newLocalPlayerDex;
    }

    [ServerRpc]
    public void UpdateIntServerRpc()
    {
        //logic to increase or decrease playerInt
        playerInt.Value = newLocalPlayerInt;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if(oldItem != null)
        {
            oldLocalPlayerStr = playerStr.Value;
            strModifier = newItem.bonusStr - oldItem.bonusStr;
            newLocalPlayerStr = oldLocalPlayerStr + strModifier;
            networkPlayerStats.UpdatePlayerStr();

            oldLocalPlayerDex = playerDex.Value;
            dexModifier = newItem.bonusDex - oldItem.bonusDex;
            newLocalPlayerDex = oldLocalPlayerDex + dexModifier;
            networkPlayerStats.UpdatePlayerDex();

            oldLocalPlayerCon = playerCon.Value;
            conModifier = newItem.bonusCon - oldItem.bonusCon;
            newLocalPlayerCon = oldLocalPlayerCon + conModifier;
            networkPlayerStats.UpdatePlayerCon();

            oldLocalPlayerInt = playerInt.Value;
            intModifier = newItem.bonusInt - oldItem.bonusInt;
            newLocalPlayerInt = oldLocalPlayerInt + intModifier;
            networkPlayerStats.UpdatePlayerInt();
        }
        else
        {
            oldLocalPlayerStr = playerStr.Value;
            strModifier = newItem.bonusStr;
            newLocalPlayerStr = oldLocalPlayerStr + strModifier;
            networkPlayerStats.UpdatePlayerStr();

            oldLocalPlayerDex = playerDex.Value;
            dexModifier = newItem.bonusDex;
            newLocalPlayerDex = oldLocalPlayerDex + dexModifier;
            networkPlayerStats.UpdatePlayerDex();

            oldLocalPlayerCon = playerCon.Value;
            conModifier = newItem.bonusCon;
            newLocalPlayerCon = oldLocalPlayerCon + conModifier;
            networkPlayerStats.UpdatePlayerCon();

            oldLocalPlayerInt = playerInt.Value;
            intModifier = newItem.bonusInt;
            newLocalPlayerInt = oldLocalPlayerInt + intModifier;
            networkPlayerStats.UpdatePlayerInt();
        }

    }

}
