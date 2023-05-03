using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BodyText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private void Update()
    {
        if (Game.instance.bodyText == null)
        {
            Game.instance.bodyText = textMeshPro;
        }
    }
}
