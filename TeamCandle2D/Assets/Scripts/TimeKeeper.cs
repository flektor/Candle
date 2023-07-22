using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{  
     
    public float pastTime = 0;
    [SerializeField] StateManager state;


    void Start()
    {
        Time.timeScale = 0;
        state.OnNewGame += OnNewGame;
        state.OnPlay += OnPlay;
        state.OnPause += OnPause; 
    }
     
    void Update()
    {
        if (!state.IsPlaying)
        {
            return;
        }

        pastTime += Time.deltaTime;
        TimesUp();
    }

    void TimesUp()
    {
        if (pastTime < 60 || !state.IsAlive)
        {
            return;
        } 
        state.TimesUp(); 
    }

    void OnNewGame()
    { 
        pastTime = 0;
        Time.timeScale = 1;
    }
    
    void OnPause()
    {
        Time.timeScale = 0;
    }

    void OnPlay()
    {
        Time.timeScale = 1; 
    }
}