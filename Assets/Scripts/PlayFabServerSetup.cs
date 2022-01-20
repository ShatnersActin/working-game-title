using System.Collections;
using UnityEngine;
using PlayFab;
using System.Collections.Generic;
using PlayFab.MultiplayerAgent.Model;
using Unity.Netcode;

public class PlayFabServerSetup : NetworkBehaviour
{

	private List<ConnectedPlayer> _connectedPlayers;

	void Start()
	{
        if (IsServer)
        {
			StartRemoteServer();
        }
	}

	public void OnStartLocalServerButtonClick()
	{

	}

	private void StartRemoteServer()
	{
		Debug.Log("[ServerStartUp].StartRemoteServer");
		_connectedPlayers = new List<ConnectedPlayer>();
		PlayFabMultiplayerAgentAPI.Start();
		PlayFabMultiplayerAgentAPI.OnShutDownCallback += OnShutdown;
		PlayFabMultiplayerAgentAPI.OnAgentErrorCallback += OnAgentError;

		StartCoroutine(ReadyForPlayers());
		StartCoroutine(ShutdownServerInXTime());
	}

	IEnumerator ShutdownServerInXTime()
	{
		yield return new WaitForSeconds(300f);
		StartShutdownProcess();
	}

	IEnumerator ReadyForPlayers()
	{
		yield return new WaitForSeconds(.5f);
		PlayFabMultiplayerAgentAPI.ReadyForPlayers();
	}

	private void OnAgentError(string error)
	{
		Debug.Log(error);
	}

	private void OnShutdown()
	{
		StartShutdownProcess();
	}

	private void StartShutdownProcess()
	{
		Debug.Log("Server is shutting down");
		StartCoroutine(ShutdownServer());
	}

	IEnumerator ShutdownServer()
	{
		yield return new WaitForSeconds(5f);
		Application.Quit();
	}

}