using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelClearText : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;
    [SerializeField] private TextMeshPro _text;

    private void Awake()
    {
        _text.outlineWidth = 0.2f;
        _text.outlineColor = Color.black;
    }
    public void EndLevel()
    {
        Game.instance.EndLevel();
    }

    public void PlayLevelClearSound()
    {
        _source.PlayOneShot(_clip);
    }
}
