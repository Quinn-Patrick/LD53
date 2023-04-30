using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private GameplayInput _input;
    public float Direction = 1;
    public Vector2 StartPosition = new Vector2(11, 11);
    public Vector2 BaseVelocity = new Vector2(-3, 0);
    public float VelocityControlFactor = 2;
    [SerializeField] private List<Rigidbody2D> _packages;
    private void Awake()
    {
        Reset();
    }

    private void Reset()
    {
        gameObject.transform.position = StartPosition;
        _body.velocity = BaseVelocity * Direction;
    }
    private void FixedUpdate()
    {
        _body.velocity = new Vector2(BaseVelocity.x + (_input.LeftRight * VelocityControlFactor), 0);
        if (_input.Action && _packages.Count > 0)
        {
            Debug.Log("Dropping package.");
            Rigidbody2D package = _packages[0];
            _packages.RemoveAt(0);
            package.velocity = _body.velocity;
            package.transform.position = transform.position - new Vector3(0, 1.5f, 0);
            ParachutePackage parachute = package.GetComponent<ParachutePackage>();
            if(parachute != null)
            {
                parachute.Activated = true;
            }
        }
    }
}
