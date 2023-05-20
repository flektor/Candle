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
<<<<<<< HEAD
        pastTime = Time.time - startTime;    
    } 
     
=======
        pastTime = Time.time - startTime;
        Die();
    }

    void Die ()
    {
        if (pastTime >= 60 && isAlive)
        {
            audioSource.PlayOneShot (deathsound, volume);
            Time.timeScale = 0; 
            isAlive = false; 
        }
    }

>>>>>>> 02e945b32ff4e3bd060f4ca5048a3928f82884f2
}
