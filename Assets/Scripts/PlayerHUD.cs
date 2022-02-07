using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : NetworkBehaviour
{
    private NetworkVariable<NetworkString> playerName = new NetworkVariable<NetworkString>();

    private bool overlaySet = false;
    [SerializeField]
    private TextMeshProUGUI playerTargetText;
    [SerializeField]
    private TextMeshProUGUI statSheetText;
    [SerializeField]
    private Button addCon;
    [SerializeField]
    private GameObject inventory;

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            playerName.Value = $"Player {OwnerClientId}";
        }
        
    }

    public void SetOverlay()
    {
        var localPlayerOverlay = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        localPlayerOverlay.text = playerName.Value;
    }

    public void SetTarget()
    {
        if (gameObject.GetComponent<TargetManager>().hasTarget == true)
        {    
            playerTargetText.text = gameObject.GetComponent<TargetManager>().target.name;
        }
        else
        {
            playerTargetText.text = $"No Target";
        }

    }

    public void SetPlayerStats()
    {
        statSheetText.text = "Con: " + gameObject.GetComponent<ClientPlayerStats>().playerCon.Value + "\n" +
            "HP: " + gameObject.GetComponent<NetworkHealth>().playerCurrentHealth.Value;
    }

    public void UpdateInventoryUI()
    {
        Debug.Log("Updating UI");
    }

    void OnOpenInventory()
    {
        if (inventory.activeInHierarchy == false)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
        
    }


    private void Update()
    {
        if(!overlaySet && !string.IsNullOrEmpty(playerName.Value))
        {
            SetOverlay();
            overlaySet = true;
        }
        if(IsClient && IsOwner)
        {
            SetTarget();
        }
        if (IsClient && IsOwner)
        {
            SetPlayerStats();
        }

    }
}


