using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTrigger : MonoBehaviour
{
    public GameObject turnOn;

    private void OnTriggerEnter2D(Collider2D other) {
        turnOn.SetActive(true);

    }
}
