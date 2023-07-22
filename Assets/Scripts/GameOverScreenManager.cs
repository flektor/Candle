using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenManager : MonoBehaviour
{

    [SerializeField] StateManager state;
    [SerializeField] GameObject timesUpGif;
    [SerializeField] GameObject dieGif;
    [SerializeField] GameObject winGif;
    Image winImage;
    Image dieImage;
    Image timesUpImage;

    void Start()
    {
        winImage = winGif.GetComponent<Image>();
        dieImage = dieGif.GetComponent<Image>();
        timesUpImage = timesUpGif.GetComponent<Image>();
        state.OnNewGame += OnNewGame;
        state.OnWin += OnWin;   
        state.OnDie += OnDie;   
        state.OnTimesUp += OnTimesUp;
    }

    void OnNewGame()
    {
        winImage.enabled = false;
        dieImage.enabled = false;
        timesUpImage.enabled = false;
    }

    void OnWin()
    {
        winImage.enabled = true;
    }

    void OnDie()
    {
        dieImage.enabled = true;
    }

    void OnTimesUp()
    {
        timesUpImage.enabled = true;
    }

}
