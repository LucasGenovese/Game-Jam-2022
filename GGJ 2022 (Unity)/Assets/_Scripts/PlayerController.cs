using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _playerType;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private PlayerOneMovement _playerMovement;
    [SerializeField] public bool isOnline;
    public Player PlayerType
    {
        get { return _playerType; }
        set { _playerType = value; }
    }
    public enum Player
    {
        FirstPlayer,
        SecondPlayer
    }

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_photonView != null &&_photonView.IsMine && isOnline)
        {
            _playerMovement.ReadInput();
        }
    }

}