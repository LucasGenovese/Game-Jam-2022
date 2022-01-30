using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Audio Steps")]
    [SerializeField] private AudioSource _stepsSource;
    [SerializeField] private List<AudioClip> _stepsClips;
    [SerializeField] private List<AudioClip> _jumpClip;

    [Header("Audio Interactions")]
    [SerializeField] private AudioSource _interactionsSource;
    [SerializeField] private AudioClip _thrashClip;
    [SerializeField] private AudioClip _ingredientClip;
    [SerializeField] private AudioClip _stoveClip;

    public void AudioInteractThrash()
    {
        _interactionsSource.PlayOneShot(_thrashClip);
    }
    public void AudioInteractIngredient()
    {
        _interactionsSource.PlayOneShot(_ingredientClip);
    }
    public void AudioInteractStove()
    {
        _interactionsSource.PlayOneShot(_stoveClip, 0.2f);
    }
    public void AudioStep()
    {
        _stepsSource.PlayOneShot(_stepsClips[Random.RandomRange(0, _stepsClips.Count)], 0.3f);
    }

    public void AudioJump()
    {
        _stepsSource.PlayOneShot(_jumpClip[Random.RandomRange(0, _jumpClip.Count)], 0.2f);
    }
}
