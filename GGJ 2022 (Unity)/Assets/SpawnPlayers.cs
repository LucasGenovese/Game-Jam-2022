using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject _firstPlayer;
    [SerializeField] private GameObject _secondPlayer;
    [SerializeField] private bool playerExist = false;

    private void Start()
    {
        if (GameManager.Instance.playerOnline == false)
        {
            var player = PhotonNetwork.Instantiate(_firstPlayer.name, new Vector3(100, 100, 100), Quaternion.identity);
            player.GetComponent<PlayerController>().PlayerType = PlayerController.Player.FirstPlayer;
            player.GetComponent<PlayerController>().isOnline = true;
            LevelController.Instance.OnlinePlayerSelection(player);

            GameManager.Instance.playerOnline = true;
        }

        else
        {
            var player = PhotonNetwork.Instantiate(_secondPlayer.name, new Vector3(100, 100, 100), Quaternion.identity);
            player.GetComponent<PlayerController>().PlayerType = PlayerController.Player.SecondPlayer;
            player.GetComponent<PlayerController>().isOnline = true;
            LevelController.Instance.OnlinePlayerSelection(player);
        }
    }
}
