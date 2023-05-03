using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private GameplayInput _input;

    void Update()
    {
        if (_input.Action) SceneManager.LoadScene("LevelTransition", LoadSceneMode.Single);
    }
}
