using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayerHealth : NetworkBehaviour
{

    public void AddPlayerCon()
    {
        ulong localClientId = NetworkManager.Singleton.LocalClientId;

        if (!NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent<ClientPlayerStats>(out ClientPlayerStats clientPlayerStats))
        {
            return;
        }

        clientPlayerStats.UpdateConServerRpc();
    }
}
