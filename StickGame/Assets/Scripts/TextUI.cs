using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    // Start is called before the first frame update
    public string textValue;
    public Text textElement;
    void Start()
    {
        textElement.text = textValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
