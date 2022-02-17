using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class UIManager : NetworkBehaviour
{
    [SerializeField]
    private Button startServerButton;

    [SerializeField]
    private Button startHostButton;

    [SerializeField]
    private Button startClientButton;

    [SerializeField]
    private TextMeshProUGUI playerInGameText;

    [SerializeField]
    private TextMeshProUGUI playerTargetText;

    [SerializeField]
    private Button addOneStrButton;

    [SerializeField]
    private GameObject playerManager;

    [SerializeField]
    private GameObject player;
  
    private void Awake()
    {
        Application.targetFrameRate = 60;

        Cursor.visible = true;
        playerManager = GameObject.Find("PlayersManager");
        

    }

    private void Start()
    {
        startHostButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartHost())
            {
                Debug.Log("Host Started....");
            }
            else
            {
                Debug.Log("Host could not be started...");
            }
        });

        startServerButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartServer())
            {
                Debug.Log("Server Started....");
            }
            else
            {
                Debug.Log("Server could not be started...");
            }
        });

        startClientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }

    private void Update()
    {
    
        if (playerManager != null)
        {
            playerInGameText.text = $"Players in game: " + playerManager.GetComponent<PlayerManager>().playersInGame.Value;
        }
    }

    public void OnServerStart()
    {
 
    }
}
