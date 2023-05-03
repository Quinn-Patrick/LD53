using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public bool Delivered { get; private set; } = false;
    public float Timer { get; private set; } = 5.0f;

    public bool IsInGoal { get; private set; }

    [SerializeField] private AudioClip _enterClip;
    [SerializeField] private AudioClip _exitClip;
    [SerializeField] private AudioSource _source;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _source.PlayOneShot(_enterClip);
        IsInGoal = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _source.PlayOneShot(_exitClip);
        Timer = 5.0f;
        IsInGoal=false;
    }

    private void FixedUpdate()
    {
        if (IsInGoal)
        {
            Timer -= Time.fixedDeltaTime;
            if (Timer <= 0)
            {
                if(!Delivered)Debug.Log("Package Delivered.");
                Delivered = true;
            }
        }
    }
}
