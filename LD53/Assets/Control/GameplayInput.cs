using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInput : MonoBehaviour
{
    [SerializeField] private Control _controls;
    public float LeftRight;
    public bool Action;
    public bool Restart;

    private int _actionCooldown;
    private int _restartCooldown;
    private void Awake()
    {
        _controls = new Control();

        _controls.Gameplay.Action.performed += ctx => { Action = true; _actionCooldown = 1; };
        _controls.Gameplay.LeftRight.performed += ctx =>
        {
            LeftRight = ctx.ReadValue<float>();
            if(LeftRight > 0) LeftRight = 1;
            if(LeftRight < 0) LeftRight = -1;
        };
        _controls.Gameplay.LeftRight.canceled += ctx => LeftRight = 0;
        _controls.Gameplay.Restart.performed += ctx => { Restart = true; _restartCooldown = 1; };
    }

    private void FixedUpdate()
    {
        if(Restart && _restartCooldown <= 0)Restart = false;
        _restartCooldown--;
        if(Action && _actionCooldown <= 0)Action = false;
        _actionCooldown--;
    }

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }
}
