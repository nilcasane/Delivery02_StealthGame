using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    void OnStart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
