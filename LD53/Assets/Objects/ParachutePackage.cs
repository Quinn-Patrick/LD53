using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachutePackage : MonoBehaviour
{
    [SerializeField] private GameplayInput _input;
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private HingeJoint2D _joint;
    private bool _controllable = true;
    public bool Activated;
    private int frames = 0;

    private void FixedUpdate()
    {
        if(_controllable && Activated)_body.AddForce(_input.LeftRight * new Vector2(5, 0), ForceMode2D.Force);
        if (_input.Action && frames >= 2) LoseParachute();
        if (Activated) frames++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Activated)LoseParachute();
    }

    private void LoseParachute()
    {
        if (_joint != null) Destroy(_joint);
        _body.gravityScale = 1;
        _body.drag = 0;
        _controllable = false;
    }
}
