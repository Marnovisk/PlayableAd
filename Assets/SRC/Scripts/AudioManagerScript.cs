using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioSource _mainAudio;
    public AudioSource _alertAudio;
    public AudioSource _GameOverAudio;
    public AudioSource _matchAudio;

    public AudioClip _loseAudio;
    public AudioClip _winAudio;
    
    public void PlayAlert()
    {
        Debug.Log("Alert on AudioManager");
        _alertAudio.Play();
    }

    public void StopAlert()
    {
        _alertAudio.Stop();
    }

    public void PlayMatch()
    {
        _matchAudio.Play();
    }

    public void PlayGameOver(bool win)
    {
        StopAlert();

        if (win)
        {
            _GameOverAudio.clip = _winAudio;
            _GameOverAudio.Play();
        }
        else
        {
            _GameOverAudio.clip = _loseAudio;
            _GameOverAudio.Play();
        }
    }
}
