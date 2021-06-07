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
    public GameObject inventory;

    public GameObject smallPaper;

    public bool planeSpawned;
    private Vector2 target;
    private Vector2 targetPlane;

    private Vector2 position;
    private Vector2 positionPlane;


    private GameObject plane;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (itemObtained == true)
        {
            Destroy(paper);
        }
        if (itemObtained == true)
        {
           CreateInventory();
        }


    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Vector2 move = transform.position;
        move.x = move.x + speed * horizontal * Time.deltaTime;
        if (planeSpawned)
        {
            float step = speed * Time.deltaTime;
            target = new Vector2(28f, 1.5f);
            targetPlane = new Vector2(28f, -1.67f);
            position = gameObject.transform.position;
            positionPlane = plane.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            plane.transform.position = Vector2.MoveTowards(plane.transform.position, targetPlane, step);
        }
    }

    public void flyAway(GameObject planeSpawn)
    {
            plane = planeSpawn;
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
        CreateInventory();
    }

    public void CreateInventory() {
         if (itemObtained == true)
        {
           GameObject inventoryUI = Instantiate(inventory);
           GameObject paperInventory = Instantiate(smallPaper);
        }
    }

}
