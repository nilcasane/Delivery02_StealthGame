using System;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public enum GameResult { None, Win, Lose }
    public static GameResult LastResult { get; private set; }

    public static Action OnPlayerWin;
    public static Action OnPlayerLose;

    private void OnEnable()
    {
        OnPlayerWin += PlayerWin;
        OnPlayerLose += PlayerLose;
    }

    private void OnDisable()
    {
        OnPlayerWin -= PlayerWin;
        OnPlayerLose -= PlayerLose;
    }

    private void PlayerLose()
    {
        TimeManager.Reset();
        LastResult = GameResult.Lose;
        SceneManager.LoadScene("Ending");
    }

    private void PlayerWin()
    {
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
