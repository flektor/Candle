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

    void Start()
    {
        winGif.GetComponent<Image>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<CharacterController>() != null && running)
        {
            Debug.Log("You Won");
            winGif.GetComponent<Image>().enabled = true;
            GetComponent<AudioSource>().PlayOneShot(winSound, 2f);
            running = false;
            tk.isAlive = false;
        }
    }
}
