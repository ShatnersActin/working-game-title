using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button startServerButton;

    [SerializeField]
    private Button startHostButton;

    [SerializeField]
    private Button startClientButton;

    [SerializeField]
    //private TextMeshProUGUI playerInGameText;

    //private int numberOfPlayers;

    private void Awake()
    {
        Cursor.visible = true;
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
        //GameObject playerManager = GameObject.Find("PlayersManager");
        //playerInGameText.text = $"Players in game: " + playerManager.GetComponent<PlayerManager>().playersInGame.Value;
        
    }
}
