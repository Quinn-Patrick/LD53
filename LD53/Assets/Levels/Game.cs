using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game instance = null;
    [SerializeField] private List<GameObject> levels = new List<GameObject> ();
    [SerializeField] private GameplayInput _input;
    private GameObject _currentLevel = null;
    private float _restartCooldown = 3f;
    public string GameStatus { get; private set; } = "Between";

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        StartCoroutine(LoadLevel());
        GameStatus = "Level";
    }

    private IEnumerator LoadLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _currentLevel = null;
        }
        yield return new WaitForSeconds(0.1f);
        _currentLevel = Instantiate(levels[0], new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void EndLevel()
    {
        levels.Remove(levels[0]);
        SceneManager.LoadScene("LevelTransition", LoadSceneMode.Single);
        GameStatus = "Between";
    }

    private void Update()
    {
        _restartCooldown -= Time.deltaTime;
        if (_input.Action && GameStatus == "Between")
        {
            Debug.Log("Attempting to advance to the next level.");
            StartLevel();
        }

        if (_input.Restart && GameStatus == "Level" && _restartCooldown <= 0)
        {
            _restartCooldown = 3;
            StartLevel();
        }
    }
}
