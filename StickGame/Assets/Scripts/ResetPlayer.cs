using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        Vector2 position = transform.position;
        position.x = -6.71f;
        position.y = 0f;
        controller.transform.position = position;
        if (controller != null)
        {
           controller.transform.position = position;
        }
    }
}
