using UnityEngine; 

public class Goal : MonoBehaviour
{
    [SerializeField] StateManager state;
    bool running = true;
  
    void Start()
    { 
        state.OnNewGame += OnNewGame;
    }

    void OnNewGame()
    { 
        running = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.GetComponent<CharacterController>() != null && running)
        { 
            running = false;
            state.IsWon = true;
        }
    }
}
