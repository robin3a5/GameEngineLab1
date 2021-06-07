using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            if(controller.hasItem == false )
            {
                controller.ObtainItem(true);
                Destroy(gameObject);
            }
        }
    }
}
