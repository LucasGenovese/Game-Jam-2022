using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomInput;


    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(roomInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomInput.text);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("PhotonNetwork: Is Master Client");
        }

        PhotonNetwork.LoadLevel("Game-Online");
    }
}
