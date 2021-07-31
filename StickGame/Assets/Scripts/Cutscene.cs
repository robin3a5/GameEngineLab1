using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public GameObject cam1;
    public GameObject mainCamera;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        
        if (controller != null)
        {
            if (controller.hasItem)
            {
                 StartCoroutine(CutScene());
            }
            
        }     
    } 

    IEnumerator CutScene() {
        yield return new WaitForSeconds(3);

        cam1.SetActive(true);

        mainCamera.SetActive(false);
        yield return new WaitForSeconds(1.3f);


        mainCamera.SetActive(true);
        cam1.SetActive(false);



    }
}
