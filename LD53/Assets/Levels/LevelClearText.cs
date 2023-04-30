using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClearText : MonoBehaviour
{
    public void EndLevel()
    {
        Game.instance.EndLevel();
    }
}
