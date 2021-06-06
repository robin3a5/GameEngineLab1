using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
   [SerializeField] private string newScene;

  
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("Player"))
       {
           SceneManager.LoadScene(newScene);
       }
   }
}
