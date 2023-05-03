using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAudio : MonoBehaviour
{
    [SerializeField] protected AudioSource _source;
    [SerializeField] protected AudioClip _clip;
    public void PlaySoundWithVolume(AudioClip _clip, float volume)
    {
        _source.PlayOneShot(_clip, volume);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlaySoundWithVolume(_clip, collision.relativeVelocity.magnitude / 2);
    }
}
