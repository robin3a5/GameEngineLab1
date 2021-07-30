using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LampController : MonoBehaviour
{
    public GameObject lampOff;
    public GameObject lampOn;
    bool isOn = false;

    public void alternateState() {
        isOn = !isOn;
        lampOff.SetActive(false);
    }
}
