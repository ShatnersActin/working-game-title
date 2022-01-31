using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ClientPlayerStats : NetworkBehaviour
{
    public NetworkVariable<int> playerCon = new NetworkVariable<int>();
    public NetworkVariable<int> playerHealth = new NetworkVariable<int>();

    [ServerRpc]
    public void UpdateConServerRpc()
    {
        playerCon.Value++;
    }

}
