using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _winObject;
    [SerializeField] private GameObject _loseObject;

    public static GameManager Instance;
    public UnityEvent OnWin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Win()
    {
        _winObject.SetActive(true);
        OnWin.Invoke();
        int cureentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        Progress.Instance.SetLevel(cureentLevelIndex + 1);
        Progress.Instance.AddCoins(50);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(Progress.Instance.Level);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Lose()
    {
        _loseObject.SetActive(true);
    }
}
