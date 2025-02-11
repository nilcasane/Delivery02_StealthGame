using System;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public enum GameResult { None, Win, Lose }
    public static GameResult LastResult { get; private set; }

    // Eventos estáticos para victoria/derrota
    public static Action OnPlayerWin;
    public static Action OnPlayerLose;

    private void OnEnable()
    {
        OnPlayerWin += PlayerWon;
        OnPlayerLose += PlayerDied;
    }
    private void OnDisable()
    {
        OnPlayerWin -= PlayerWon;
        OnPlayerLose -= PlayerDied;
    }
    private void PlayerDied()
    {
        LastResult = GameResult.Lose;
        SceneManager.LoadScene("Ending");
    }

    private void PlayerWon()
    {
        Debug.Log("Time: " + TimeManager.Timer);
        Debug.Log("Distance: " + PlayerMove.Distance);
        ScoreManager.OnScoreUpdated(TimeManager.Timer, PlayerMove.Distance);
        TimeManager.Reset();
        LastResult = GameResult.Win;
        SceneManager.LoadScene("Ending");
    }

    public static void ResetGame()
    {
        LastResult = GameResult.None;
    }
}
