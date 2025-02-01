using UnityEngine;

public class ExitManager : MonoBehaviour
{
    void OnMove()
    {
        // Exit the game (only in builds)
        Application.Quit();

        // If running in the editor, stop play mode (only for testing)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
