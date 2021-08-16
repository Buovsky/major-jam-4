using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    public GameObject turnOn;
    // Start is called before the first frame update
    void Start()
    {
        turnOn.SetActive(true);
    }

}
