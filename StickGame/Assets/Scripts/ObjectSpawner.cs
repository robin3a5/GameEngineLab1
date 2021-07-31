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
    public GameObject dialogue;

    public GameObject cam1;
    public GameObject mainCamera;



    public void spawn(Rigidbody2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            if (controller.hasItem)
            {
                 StartCoroutine(CutScene(controller));
            }
        }
    } 

    IEnumerator CutScene(PlayerController controller) {
                controller.canMove = false;
                Input.ResetInputAxes();
                controller.moveAnim = true;
                
                GameObject fanCopy = fan;
                GameObject outletCopy = outlet;

                Destroy(fanCopy);
                Destroy(outletCopy);
                GameObject pluggedFan = Instantiate(pluggedInFan);
                GameObject firstBreeze = Instantiate(breeze1);
                GameObject secondBreeze = Instantiate(breeze2);
                GameObject thirdBreeze = Instantiate(breeze3);
                GameObject chatBox = Instantiate(dialogue);

               
                yield return new WaitForSeconds(3);
                Destroy(chatBox);

                GameObject airplane = Instantiate(plane);
                controller.planeSpawned = true;
                controller.flyAway(airplane);
                cam1.SetActive(true);

                mainCamera.SetActive(false);
                 yield return new WaitForSeconds(1.3f);


                 mainCamera.SetActive(true);
                 cam1.SetActive(false);

                
    }

    
    
}
