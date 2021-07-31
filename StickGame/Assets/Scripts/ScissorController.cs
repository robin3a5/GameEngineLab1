using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScissorController : MonoBehaviour
{

    public float speed;
    public float changeTime = 3.0f;

    public GameObject key;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void OnTriggerEnter2D(Collider2D  other)
{
    PlayerController player = other.gameObject.GetComponent<PlayerController>();

    if (player != null)
    {
        Vector2 position = transform.position;
        position.x = -7.88f;
        position.y = -2.71f;
        player.transform.position = position;
        if (player != null)
        {
           player.transform.position = position;
           if (player.hasItem)
           {
               PlayerController.itemObtained = false;
               string currentSceneName = SceneManager.GetActiveScene().name;
               SceneManager.LoadScene(currentSceneName);
           }
        }
    }
}

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        
        position.y = position.y + Time.deltaTime * speed * direction;;
        
        rigidbody2D.MovePosition(position);
    }
}
