using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBar : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float startX;
    [SerializeField] private float endX;
    [SerializeField] private Rigidbody2D _body;

    private void Awake()
    {
        _body.velocity = new Vector2(startSpeed, 0);
    }

    private void FixedUpdate()
    {
        if(transform.position.x < endX)
        {
            transform.position = new Vector2(startX, transform.position.y);
        }
    }
}
