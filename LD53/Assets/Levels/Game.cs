using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public static Game instance = null;
    [SerializeField] private List<GameObject> levels = new List<GameObject> ();
    [SerializeField] private GameplayInput _input;
    private GameObject _currentLevel = null;
    private float _restartCooldown = 3f;
    public string GameStatus { get; private set; } = "Between";

    public List<Email> Emails = new List<Email> ();

    public TextMeshProUGUI fromText;
    public TextMeshProUGUI subjectText;
    public TextMeshProUGUI bodyText;
    private int level = 1;

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
        level++;
        SceneManager.LoadScene("LevelTransition", LoadSceneMode.Single);
        GameStatus = "Between";
    }

    private void Update()
    {
        if (GameStatus == "Between")
        {
            if (fromText != null && bodyText != null && subjectText != null)
            {
                //Debug.Log("Found textmeshes.");
                Email currentEmail = Emails[level - 1];
                if (currentEmail != null)
                {
                    //Debug.Log("Setting email text.");
                    fromText.text = currentEmail.From;
                    subjectText.text = currentEmail.Subject;
                    bodyText.text = currentEmail.Body;
                }
            }
        }

        _restartCooldown -= Time.deltaTime;
        if (_input.Action && GameStatus == "Between" && levels.Count > 0)
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
