using UnityEngine;
using UnityEngine.UI;


//Attach this script to the circular sprite Mask
public class VisibilityController : MonoBehaviour
{
    //Refrence to the position of the player
    public GameObject player;

    public TimeKeeper tk;

    private Vector3 startingScale;

    private bool running = true;

    public Image timesUp;

    // Start is called before the first frame update
    void Start()
    {
        startingScale = transform.localScale;
        tk.OnNewGame += OnNewGame;
    }

    void OnNewGame()
    {
        timesUp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = player.transform.position;

        if (!running)
        {
            return;
        }
        transform.localScale = startingScale * (1 - (tk.pastTime / 60f));

        if (tk.pastTime <= 60)
        {
            return;
        }
        timesUp.enabled = true;
        running = false;
    }
}
