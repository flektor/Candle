using UnityEngine;

public class TimeKeeper : MonoBehaviour
{  
     
    public float pastTime = 0;
    public AudioSource audioSource;
    public AudioClip gamesound; 
    public AudioClip deathsound;
    public float volume; 
    public bool isAlive; 
    public bool isPlaying;
    public bool isWon = false;

    public OnPauseCallback OnPause;
    public delegate void OnPauseCallback();
    public OnPlayCallback OnPlay;
    public delegate void OnPlayCallback();
    public OnNewGameCallback OnNewGame;
    public delegate void OnNewGameCallback();
    public OnDieCallback OnDie;
    public delegate void OnDieCallback(); 


    void Start()
    {
        Time.timeScale = 0;
    }
     
    void Update()
    {
        if (!isPlaying)
        {
            return;
        }

        pastTime += Time.deltaTime;
        Die();
    }

    void Die()
    {
        if (pastTime < 60 || !isAlive)
        {
            return;
        }
        audioSource.PlayOneShot(deathsound, volume);
        isPlaying = false;
        OnDie?.Invoke();
    }

    public void NewGame()
    {
        isPlaying = true;
        isWon = false;
        isAlive = true;
        pastTime = 0;
        audioSource.PlayOneShot(gamesound, volume);
        Time.timeScale = 1;
        OnNewGame?.Invoke();
        OnPlay?.Invoke();
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
        isPlaying = false;
        OnPause?.Invoke();
    }

    public void Resume()
    {
        if(!isAlive || isWon)
        {
            NewGame();
            return;
        }

        Time.timeScale = 1; 
        isPlaying = true;
        OnPlay?.Invoke();  
    }

}
