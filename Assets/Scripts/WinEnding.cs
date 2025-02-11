using UnityEngine;
using UnityEngine.UI;

public class WinEnding : MonoBehaviour
{
    [SerializeField]
    private Text _highScore;
    [SerializeField]
    private Text _score;

    void Start()
    {
        _highScore.text = "HighScore: " + ScoreManager.HighScore;
        _score.text = "Score: " + ScoreManager.LastScore;
    }
}
