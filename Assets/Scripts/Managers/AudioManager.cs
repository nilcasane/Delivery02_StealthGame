using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    private AudioSource _audioSource;

    [Header("Audio Clips")]
    public AudioClip BackgroundMusic;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = BackgroundMusic;
        _audioSource.Play();
    }
}
