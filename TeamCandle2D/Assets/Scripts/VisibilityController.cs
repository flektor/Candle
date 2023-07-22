using UnityEngine;
using UnityEngine.UI;


//Attach this script to the circular sprite Mask
public class VisibilityController : MonoBehaviour
{
    //Refrence to the position of the player
    public GameObject player;

    [SerializeField] TimeKeeper tk;
    [SerializeField] StateManager state;

    private Vector3 startingScale;

    private bool running = true;
 
    // Start is called before the first frame update
    void Start()
    {
        startingScale = transform.localScale;
        state.OnNewGame += OnNewGame;
    }

    void OnNewGame()
    { 
        running = true;
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

        if (tk.pastTime > 60f)
        {
            running = false; 
        }
    }
}
