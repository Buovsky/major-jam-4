using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject doorRef;
    public GameObject buttonActivate;
    public GameObject buttonDeactivate;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            doorRef.SetActive(false);
            buttonActivate.SetActive(true);
            buttonDeactivate.SetActive(false);
        }
    }
}
