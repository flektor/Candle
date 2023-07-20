using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public GameObject winGif;
    public AudioClip winSound;
    public bool running = true;
    public TimeKeeper tk;
    Image winImage;
    AudioSource _audio;
    
    void Start()
    {
        _audio = GetComponent<AudioSource>();
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
            _audio.PlayOneShot(winSound, 2f);
            running = false;
            tk.isPlaying = false;
            tk.isWon = true;
        }
    }
}
