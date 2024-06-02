using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private AudioClip[] _grassFootsteps_AudioClip;
    
    public void Footstep() => _playerAudioSource.PlayOneShot(GetRandomSound(_grassFootsteps_AudioClip));
    private AudioClip GetRandomSound(AudioClip[] array)
    {
        int randomIndex = Random.Range(0, array.Length);
        return array[randomIndex];
    }
}
