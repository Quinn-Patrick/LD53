using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trembling : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;
    private const float ForceFactor = 2.0f;
    private void FixedUpdate()
    {
        _body.velocity = Vector2.zero;
        _body.AddForce(new Vector2(Random.Range(-ForceFactor, ForceFactor), Random.Range(-ForceFactor, ForceFactor)), ForceMode2D.Impulse);
    }
}
