using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SubjectLine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private void Update()
    {
        if (Game.instance.subjectText == null)
        {
            Game.instance.subjectText = textMeshPro;
        }
    }
}
