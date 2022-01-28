using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _playerType;
    public enum Player
    {
        FirstPlayer,
        SecondPlayer
    }

    public Player PlayerType => _playerType;
}
