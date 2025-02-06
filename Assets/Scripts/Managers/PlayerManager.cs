using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerKiller.OnPlayerKilled += GameOver;
    }
    private void OnDisable()
    {
        PlayerKiller.OnPlayerKilled -= GameOver;
    }
    private void GameOver()
    {
        SceneManager.LoadScene("Ending");
    }
}
