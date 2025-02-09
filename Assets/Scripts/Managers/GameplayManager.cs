using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerKiller.OnPlayerKilled += GameOver;
        AxeScript.OnAxePicked += Win;
    }
    private void OnDisable()
    {
        PlayerKiller.OnPlayerKilled -= GameOver;
        AxeScript.OnAxePicked -= Win;
    }
    private void GameOver()
    {
        SceneManager.LoadScene("Ending");
    }
    private void Win()
    {
        SceneManager.LoadScene("Ending");
    }
}
