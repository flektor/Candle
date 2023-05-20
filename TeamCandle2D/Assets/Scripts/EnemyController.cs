using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform startingPoint;
    public Transform endingPoint;

    private float progress = 0;

    public Image gameOver;
    public float speed = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        progress = progress + speed * Time.deltaTime;

        
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
            Debug.Log("Hit player");
            gameOver.enabled = true;
            Time.timeScale = 0;
        }
    }
}
