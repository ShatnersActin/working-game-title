using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
    public NetworkVariable<int> playersInGame = new NetworkVariable<int>();

    public int PlayersInGame
    {
        get
        {
            return playersInGame.Value;
        }
    }


            // Start is called before the first frame update
            void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) => 
        {

            Debug.Log($"{id} just connected...");
            playersInGame.Value++;
            Debug.Log("Total Players : " + playersInGame.Value);

        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            Debug.Log($"{id} just disconnected...");
            playersInGame.Value--;
            Debug.Log("Total Players : " + playersInGame.Value);
        };

    }

}
