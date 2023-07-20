using UnityEngine;

public class AudioManager : MonoBehaviour
{ 
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip gameSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] float volume = .5f;
    [SerializeField] TimeKeeper timeKeeper;
    AudioSource _soundsSource; 
    AudioSource _musicSource; 

    void Start()
    {
        _soundsSource = gameObject.AddComponent<AudioSource>();
        _musicSource = gameObject.AddComponent<AudioSource>();
        timeKeeper.OnNewGame += OnNewGame;
        timeKeeper.OnTimesUp += OnDie;
        timeKeeper.OnDie += OnDie;
        timeKeeper.OnWin += OnWin;
        timeKeeper.OnPlay += OnPlay;
        timeKeeper.OnPause += OnPause;
    }

    void OnNewGame()
    {  
        _musicSource.PlayOneShot(gameSound, volume);
    }

    void OnPlay()
    {
        _musicSource.UnPause();
    }

    void OnPause()
    {
        _musicSource.Pause();
    }

    void OnWin()
    {
        _musicSource.Stop();
        _soundsSource.PlayOneShot(winSound, volume);
    }
       
    void OnDie()
    {
        _musicSource.Stop();
        _soundsSource.PlayOneShot(deathSound, volume);
    } 
}
