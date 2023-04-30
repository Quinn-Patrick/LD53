using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Package> _packages;
    [SerializeField] private Animator _endTextAnimator;
    public bool LevelOver { get; private set; } = false;

    private void FixedUpdate()
    {
        if (LevelOver)
        {
            _endTextAnimator.SetBool("HasPlayed", true);
        }
        foreach (var package in _packages)
        {
            if (!package.Delivered)
            {
                break;
            }
            LevelOver = true;
            _endTextAnimator.SetBool("LevelOver", true);
        }
    }
}
