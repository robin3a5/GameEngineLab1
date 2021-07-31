using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 10.0f;

    public Animator animator;
    public bool hasItem { get { return itemObtained; } }
    public static bool itemObtained;

    static string id;


    public GameObject paper;
    public GameObject inventory;

    public GameObject smallPaper;

    public GameObject chatBox;

    public bool planeSpawned;
    private Vector2 target;
    private Vector2 targetPlane;

    private Vector2 position;
    private Vector2 positionPlane;

    private GameObject plane;

    public GameObject lampOff;
    public GameObject lampOn;

    public GameObject pen;
    public GameObject smallPen;
    public GameObject chartUp;
    public GameObject chartDown;
    public GameObject inventoryTip;
    public GameObject arrow;
    public GameObject smallPlane;
    public GameObject key;
    public GameObject smallKey;
    public GameObject ChestClosed;
    public GameObject ChestOpen;
    public GameObject ChestChat;
    public GameObject itemPickup;
    public GameObject balanceSheet1;
    public GameObject balanceSheet2;
    public GameObject moneyBag;
    public GameObject moneyBag1;
    public GameObject moneyBag2;






    private bool dance = false;

    public bool canMove = true;

    public bool moveAnim = false;

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (itemObtained == true)
        {
            Destroy(paper);
            Destroy(pen);
            Destroy(key);
        }
        if (itemObtained == true)
        {
           CreateInventory(id);
        }

    }

    // Update is called once per frame
    void Update()
    {
            horizontal = Input.GetAxis("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            animator.SetFloat("Direction", horizontal);
            animator.SetBool("IsDancing", dance);
            animator.SetBool("moveAnim", moveAnim);
        if(canMove)
        {
            Vector2 move = transform.position;
            move.x = move.x + speed * horizontal * Time.deltaTime;
            if(horizontal > 0 || horizontal < 0){
                dance = false;
            }
            if(Input.GetButtonDown("Dance")){
                dance = true;
            }
            if(Input.GetButtonDown("Interact")){
                RaycastHit2D leftHit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1.3f, LayerMask.GetMask("Interactable"));
                RaycastHit2D rightHit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1.3f, LayerMask.GetMask("Interactable"));
                if (rightHit.rigidbody || leftHit.rigidbody)
                {
                  var rightCheck = rightHit.rigidbody ?? leftHit.rigidbody;
                   if (rightCheck.name == "Pen")
                    {
                        Destroy(pen);
                        ObtainItem(true, "pen");
                        StartCoroutine(ItemPickup());
                    }
                    else if(rightCheck.name == "DownChart") {
                        if (itemObtained)
                        {
                            chartDown.SetActive(false);
                            chartUp.SetActive(true); 
                            itemObtained = false;
                        }
                    }
                    else if (rightCheck.name == "Paper")
                    {
                        Destroy(paper);
                        ObtainItem(true, "paper");
                        StartCoroutine(ItemPickup());
                    }
                    else if (rightCheck.name == "Key")
                    {
                        Destroy(key);
                        ObtainItem(true, "key");
                        StartCoroutine(ItemPickup());
                    }
                    else if (rightCheck.name == "SpawnObjects")
                    {
                        ObjectSpawner spawner = rightCheck.GetComponent<ObjectSpawner>();
                        if (spawner)
                        {
                            spawner.spawn(rigidbody2d);
                        }
                    }
                    else if(rightCheck.name == "ChestClosed") {
                        if (itemObtained)
                        {
                            ChestClosed.SetActive(false);
                            ChestOpen.SetActive(true); 
                            itemObtained = false;
                            balanceSheet1.SetActive(false);
                            balanceSheet2.SetActive(true);
                            moneyBag.SetActive(true);
                            moneyBag1.SetActive(true);
                            moneyBag2.SetActive(true);
                        }
                        else
                        {
                            StartCoroutine(LockedChest());
                        }
                    }
                    else if(rightCheck.name == "LampOff" || rightCheck.name == "LampOn")
                    {
                        if (lampOff.activeSelf)
                        {
                            lampOff.SetActive(false);
                            lampOn.SetActive(true);
                        }
                        else 
                        {
                            lampOff.SetActive(true);
                            lampOn.SetActive(false);
                        }
                    }
                    
                }
            }
        }
        else{
            horizontal = 0;
            if (planeSpawned)
            {
                moveAnim = false;
                float step = speed * Time.deltaTime;
                target = new Vector2(28f, 1.5f);
                targetPlane = new Vector2(28f, -1.67f);
                position = gameObject.transform.position;
                positionPlane = plane.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, target, step);
                plane.transform.position = Vector2.MoveTowards(plane.transform.position, targetPlane, step);
                itemObtained = false;
            }
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

    public void ObtainItem(bool foo, string newid)
    {
        itemObtained = foo;
        id = newid;
        CreateInventory(id);
    }

    public void CreateInventory(string id) {
        if (id == "pen")
        {
            GameObject inventoryUI = Instantiate(inventory);
            GameObject penInventory = Instantiate(smallPen);
            inventoryTip.SetActive(true);
            arrow.SetActive(true);
        }
        else if (id == "paper"){
           GameObject inventoryUI = Instantiate(inventory);
           GameObject smallPlaneUI =  Instantiate(smallPlane);
        }
        else if (id == "key"){
           GameObject inventoryUI = Instantiate(inventory);
           GameObject smallKeyUI =  Instantiate(smallKey);
        }
        else if (itemObtained == true)
        {
           GameObject inventoryUI = Instantiate(inventory);
           GameObject paperInventory = Instantiate(smallPaper);
        }
        
    }

    IEnumerator LockedChest() {
                ChestChat.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                ChestChat.SetActive(false);
    }

    IEnumerator ItemPickup() {
                itemPickup.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                itemPickup.SetActive(false);
    }

}
