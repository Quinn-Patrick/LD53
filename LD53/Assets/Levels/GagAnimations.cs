using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GagAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Package package = null;

    private void FixedUpdate()
    {
        if(package == null)
        {
            package = FindObjectOfType<Package>();
            if (package == null) return;
        }

        animator.SetBool("InGoal", package.IsInGoal);
    }
}
