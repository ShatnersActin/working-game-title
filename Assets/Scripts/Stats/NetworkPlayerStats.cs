using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayerStats : NetworkBehaviour
{
    /// <summary>
    /// Network Class that contains functions to call to perform server side updates to Stats.
    /// These are all Client Side calls that are handled by the Server.  
    /// IsClient checks are necessary to prevent the server from trying to get its on LocalClient, since it doesn't have one
    /// </summary>
    /// 

    //ulong localClientId = NetworkManager.Singleton.LocalClientId;


    public void UpdatePlayerStr()
    {
        if (IsClient)
        {
            if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
            {
                return;
            }

            clientPlayerStats.UpdateStrServerRpc();
        }

    }

    public void UpdatePlayerDex()
    {
        if (IsClient)
        {
            if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
            {
                return;
            }

            clientPlayerStats.UpdateDexServerRpc();
        }

    }

    public void UpdatePlayerCon()
    {
        if (IsClient)
        {
            if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
            {
                return;
            }

            clientPlayerStats.UpdateConServerRpc();
        }

    }

    public void UpdatePlayerInt()
    {
        if (IsClient)
        {
            if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
            {
                return;
            }

            clientPlayerStats.UpdateIntServerRpc();
        }

    }

    public void CalculateMaxHealth()
    {
        if (IsClient)
        {
            if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<NetworkHealth>(out NetworkHealth networkHealth))
            {
                return;
            }

            networkHealth.CalulateMaxHealthServerRpc();
        }

    }
}


