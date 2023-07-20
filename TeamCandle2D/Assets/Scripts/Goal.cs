using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public GameObject winGif;
    public bool running = true;
    public TimeKeeper tk;
    Image winImage;
   
    void Start()
    {
         winImage = winGif.GetComponent<Image>();
        tk.OnNewGame += OnNewGame;
    }

    void OnNewGame()
    {
        winImage.enabled = false;
        running = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<CharacterController>() != null && running)
        {
            Debug.Log("You Won");
            winImage.enabled = true;
            running = false;
            tk.isPlaying = false;
            tk.IsWon = true;
        }
    }
}
