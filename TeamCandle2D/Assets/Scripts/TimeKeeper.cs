using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{  
     
    public float pastTime = 0;
    public bool isPlaying;
    [SerializeField] Image timesUp;


    bool isAlive;
    public bool IsAlive
    {
        set
        {
            isAlive = value;
            if(!isAlive)
            {
                OnDie?.Invoke();
            }
        }
        get { return isAlive; }
    }

    bool isWon;
    public bool IsWon { 
        set { 
            isWon = value;
            if(isWon)
            {
                OnWin?.Invoke();
            }
        }
        get { return isWon; } 
    }

    public OnPauseCallback OnPause;
    public delegate void OnPauseCallback();
    public OnPlayCallback OnPlay;
    public delegate void OnPlayCallback();
    public OnNewGameCallback OnNewGame;
    public delegate void OnNewGameCallback();
    public OnTimesUpCallback OnTimesUp;
    public delegate void OnTimesUpCallback();
    public OnWinCallback OnWin;
    public delegate void OnWinCallback();
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
        isPlaying = false;
        timesUp.enabled = true;
        OnTimesUp?.Invoke();
    }

    public void NewGame()
    {
        timesUp.enabled = false;
        isPlaying = true;
        isWon = false;
        isAlive = true;
        pastTime = 0;
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