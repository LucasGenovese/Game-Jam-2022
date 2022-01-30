using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _overall;

    private static int _animatorTriggerHash; 


    private void Awake()
    {
        _animatorTriggerHash = Animator.StringToHash("Show");
    }

    public void ShowScore(string scoreText)
    {
        _text.text = scoreText;
        _animator.SetTrigger(_animatorTriggerHash);
    }
}
