using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    private float startTime;
    public float pastTime = 0;
    public AudioSource audioSource;
    public AudioClip gamesound; 
    public AudioClip deathsound;
    public float volume; 
    bool isAlive = true; 

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        audioSource.PlayOneShot (gamesound, volume);
    }

    // Update is called once per frame
    void Update()
    {
        pastTime = Time.time - startTime;
        Die();
    }

    void Die ()
    {
        if (pastTime >= 10 && isAlive)
        {
            audioSource.PlayOneShot (deathsound, volume);
            Time.timeScale = 0; 
            isAlive = false; 
        }
    }

}
