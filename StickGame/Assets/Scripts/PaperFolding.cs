using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFolding : MonoBehaviour
{

    public GameObject paper1;
    public GameObject paper2;
    public GameObject paper3;
    public GameObject paper4;
    public GameObject paper5;
    
    private int foldPhase = 1;

    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (foldPhase == 1)
            {
                GameObject paperFold1 = Instantiate(paper1);
                Destroy(paperFold1);
                GameObject paperFold2 = Instantiate(paper2);
                foldPhase ++;
            }  
            if (foldPhase == 2)
            {
                // GameObject paperFold3 = Instantiate(paper3);
                // Destroy(paperFold2);
                // Destroy(paper2);
                // Instantiate(paper3);
            }   
            if (foldPhase == 3)
            {
                GameObject paperFold1 = Instantiate(paper1);
                Destroy(paperFold1);
                GameObject paperFold2 = Instantiate(paper2);
                Destroy(paper3);
                Instantiate(paper4);
            }   
            if (foldPhase == 4)
            {
                GameObject paperFold1 = Instantiate(paper1);
                Destroy(paperFold1);
                GameObject paperFold2 = Instantiate(paper2);
                Destroy(paper4);
                Instantiate(paper5);
            }   
            if (foldPhase == 5)
            {
                GameObject paperFold1 = Instantiate(paper1);
                Destroy(paperFold1);
                GameObject paperFold2 = Instantiate(paper2);
                Destroy(paper1);
                Instantiate(paper2);
            }    
            
        }
    }
}
