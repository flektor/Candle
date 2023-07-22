using UnityEngine;

public class StateManager : MonoBehaviour
{

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
    public bool IsPlaying { get; private set; }
    bool isTimesUp = false;

    bool isAlive;
    public bool IsAlive
    {
        set
        {
            isAlive = value;
            IsPlaying = value;

            if (!isAlive)
            {
                OnDie?.Invoke();
            }
        }
        get { return isAlive; }
    }

    bool isWon;
    public bool IsWon
    {
        set
        {
            isWon = value;
            if (isWon)
            {
                IsPlaying = false;
                OnWin?.Invoke();
            }
        }
        get { return isWon; }
    }

    public void NewGame()
    {
        IsWon = false;
        IsAlive = true; 
        OnNewGame?.Invoke();
        Play();
    }


    public void Resume()
    {
        if (!IsAlive || isWon || isTimesUp)
        {
            NewGame();
            return;
        }

        Play();
    }

    public void Pause()
    {
        IsPlaying = false;
        OnPause?.Invoke();
    } 

    public void Play()
    {
        IsPlaying = true;
        OnPlay?.Invoke();
    }

    public void TimesUp()
    {
        IsPlaying = false;
        isTimesUp = true;
        OnTimesUp?.Invoke();
    } 
}
