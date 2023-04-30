using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public bool Delivered { get; private set; } = false;
    public float Timer { get; private set; } = 5.0f;

    public bool IsInGoal { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered goal.");
        IsInGoal = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited goal.");
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
