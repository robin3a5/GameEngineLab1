using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 10.0f;

    public bool hasItem { get { return itemObtained; } }
    static bool itemObtained;

    public GameObject paper;

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (itemObtained == true)
        {
            Destroy(paper);
        }

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        Vector2 move = transform.position;
        move.x = move.x + speed * horizontal * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ObtainItem(bool foo)
    {
        itemObtained = foo;
        Debug.Log(itemObtained);
    }
}
