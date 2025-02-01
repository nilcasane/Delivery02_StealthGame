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
        SceneManager.LoadSceneAsync("Ending");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
