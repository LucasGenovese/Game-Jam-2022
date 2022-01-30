using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _hoverSounds;
    [SerializeField] private List<AudioClip> _clickSounds;
    [SerializeField] private AudioSource _audioSource;

    public void OnMouseHover()
    {
        _audioSource.PlayOneShot(_hoverSounds[Random.RandomRange(0, _hoverSounds.Count)]);
    }

    public void OnMouseClick()
    {
        _audioSource.PlayOneShot(_clickSounds[Random.RandomRange(0, _clickSounds.Count)]);
    }
}
