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
            Debug.Log("Player " + OwnerClientId + " playerStr went from " + oldValue + " to " + newValue);
        }
    }

    void dexValueChanged(int oldValue, int newValue)
    {
        if (oldValue != newValue)
        {
            Debug.Log("Player " + OwnerClientId + "playerDex went from " + oldValue + " to " + newValue);
        }
    }

    void conValueChanged(int oldValue, int newValue)
    {
        if(oldValue != newValue)
        {
            Debug.Log("Player " + OwnerClientId + " playerCon went from " + oldValue + " to " + newValue);
            networkPlayerStats.CalculateMaxHealth();
        }
    }

    void intValueChanged(int oldValue, int newValue)
    {
        if (oldValue != newValue)
        {
            Debug.Log("Player " + OwnerClientId + " playerInt went from " + oldValue + " to " + newValue);
        }
    }

    //Start ServerRPC Call Block

    [ServerRpc]
    public void UpdateStrServerRpc(int value)
    {
        //logic to increase or decrease playerStr
        Debug.Log("Player " + OwnerClientId + " wants to update Str to " + value);
        playerStr.Value = value;
    }

    [ServerRpc]
    public void UpdateConServerRpc(int value)
    {
        //logic to increase or decrease playerCon.
        Debug.Log("Player " + OwnerClientId + " wants to update Con to " + value);
        playerCon.Value = value;
    }

    [ServerRpc]
    public void UpdateDexServerRpc(int value)
    {
        //logic to increase or decrease playerDex
        Debug.Log("Player " + OwnerClientId + " wants to update Dex to " + value);
        playerDex.Value = value;
    }

    [ServerRpc]
    public void UpdateIntServerRpc(int value)
    {
        //logic to increase or decrease playerInt
        Debug.Log("Player " + OwnerClientId + " wants to update Int to " + value);
        playerInt.Value = value;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if(oldItem != null)
        {
            oldLocalPlayerStr = playerStr.Value;                        //set old value to current value
            strModifier = newItem.bonusStr - oldItem.bonusStr;          //determine difference in gear bonus
            newLocalPlayerStr = oldLocalPlayerStr + strModifier;        //calculate new value
            networkPlayerStats.UpdatePlayerStr(newLocalPlayerStr);      //Send to networkPlayerStats to grab Local Client ID and call the Server

            oldLocalPlayerDex = playerDex.Value;
            dexModifier = newItem.bonusDex - oldItem.bonusDex;
            newLocalPlayerDex = oldLocalPlayerDex + dexModifier;
            networkPlayerStats.UpdatePlayerDex(newLocalPlayerDex);

            oldLocalPlayerCon = playerCon.Value;
            conModifier = newItem.bonusCon - oldItem.bonusCon;
            newLocalPlayerCon = oldLocalPlayerCon + conModifier;
            networkPlayerStats.UpdatePlayerCon(newLocalPlayerCon);

            oldLocalPlayerInt = playerInt.Value;
            intModifier = newItem.bonusInt - oldItem.bonusInt;
            newLocalPlayerInt = oldLocalPlayerInt + intModifier;
            networkPlayerStats.UpdatePlayerInt(newLocalPlayerInt);
        }
        else
        {
            oldLocalPlayerStr = playerStr.Value;
            strModifier = newItem.bonusStr;
            newLocalPlayerStr = oldLocalPlayerStr + strModifier;
            networkPlayerStats.UpdatePlayerStr(newLocalPlayerStr);

            oldLocalPlayerDex = playerDex.Value;
            dexModifier = newItem.bonusDex;
            newLocalPlayerDex = oldLocalPlayerDex + dexModifier;
            networkPlayerStats.UpdatePlayerDex(newLocalPlayerDex);

            oldLocalPlayerCon = playerCon.Value;
            conModifier = newItem.bonusCon;
            newLocalPlayerCon = oldLocalPlayerCon + conModifier;
            networkPlayerStats.UpdatePlayerCon(newLocalPlayerCon);

            oldLocalPlayerInt = playerInt.Value;
            intModifier = newItem.bonusInt;
            newLocalPlayerInt = oldLocalPlayerInt + intModifier;
            networkPlayerStats.UpdatePlayerInt(newLocalPlayerInt);
        }

    }

}
