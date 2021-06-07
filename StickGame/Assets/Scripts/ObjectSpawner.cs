using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject pluggedInFan;
    public GameObject fan;
    public GameObject outlet;
    public GameObject breeze1;
    public GameObject breeze2;
    public GameObject breeze3;
    public GameObject plane;

   void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        
        
        if (controller != null)
        {
            if (controller.hasItem)
            {
                GameObject fanCopy = fan;
                GameObject outletCopy = outlet;

                Destroy(fanCopy);
                Destroy(outletCopy);
                Destroy(gameObject);
                GameObject pluggedFan = Instantiate(pluggedInFan);
                GameObject firstBreeze = Instantiate(breeze1);
                GameObject secondBreeze = Instantiate(breeze2);
                GameObject thirdBreeze = Instantiate(breeze3);
                GameObject airplane = Instantiate(plane);
                controller.planeSpawned = true;
                controller.flyAway(airplane);
            }
            
        }

        
    }
    
}
