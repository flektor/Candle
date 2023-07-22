using UnityEngine;
 
public class EnemyController : MonoBehaviour
{
    float progress = 0;
    public Transform startingPoint;
    public Transform endingPoint;
    public float speed = 0.1f;
    [SerializeField] StateManager state;
   
    
    // Start is called before the first frame update
    void Start()
    {  
        state.OnNewGame += OnNewGame;
    }

    void OnNewGame()
    {
        transform.position = startingPoint.position;
        progress = 0;
    }

    // Update is called once per frame
    void Update()
    {    
        if(!state.IsPlaying)
        {
            return;
        }

        progress += speed * Time.deltaTime;
             
        float currentX = transform.position.x;

        transform.position = startingPoint.position + ((endingPoint.position - startingPoint.position) * Mathf.Abs(Mathf.Sin(progress)));

        float newX = transform.position.x;

        if(newX < currentX)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CharacterController>() != null)
        {
            state.IsAlive = false;
        }
    }
}
