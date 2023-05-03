using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FromText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    private void Update()
    {
        if(Game.instance.fromText == null)
        {
            Game.instance.fromText = textMeshPro;
        }
    }
}
