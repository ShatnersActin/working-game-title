using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayerStats : NetworkBehaviour
{
    /// <summary>
    /// Network Class that contains functions to call to perform server side updates to Stats.
    /// </summary>
    /// 

    //ulong localClientId = NetworkManager.Singleton.LocalClientId;


    public void UpdatePlayerStr()
    {
        if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
        {
            return;
        }

        clientPlayerStats.UpdateStrServerRpc();
    }

    public void UpdatePlayerDex()
    {
        if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
        {
            return;
        }

        clientPlayerStats.UpdateDexServerRpc();
    }

    public void UpdatePlayerCon()
    {
        if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
        {
            return;
        }

        clientPlayerStats.UpdateConServerRpc();
    }

    public void UpdatePlayerInt()
    {
        if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
        {
            return;
        }

        clientPlayerStats.UpdateIntServerRpc();
    }

    public void CalulatePlayerMaxHealth()
    {
        if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
        {
            return;
        }

        //clientPlayerStats.CalculatePlayerMaxHealthServerRpc();
    }

}


