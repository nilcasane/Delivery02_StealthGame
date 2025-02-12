using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GameplayManager;

public class EndingScene : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel; 

    void Start()
    {
        _winPanel.SetActive(GameplayManager.LastResult == GameResult.Win);
        _losePanel.SetActive(GameplayManager.LastResult == GameResult.Lose);
    }

    void OnStart()
    {
        GameplayManager.ResetGame();
        SceneManager.LoadScene("Title");
    }
}
