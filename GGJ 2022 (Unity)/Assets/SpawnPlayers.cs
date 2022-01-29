using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private bool playerExist = false;

    private void Start()
    {
        var player = PhotonNetwork.Instantiate(_player.name, new Vector3(100, 100, 100), Quaternion.identity);
        player.GetComponent<PlayerController>().isOnline = true;
        LevelController.Instance.OnlinePlayerSelection(player);
    }
}
