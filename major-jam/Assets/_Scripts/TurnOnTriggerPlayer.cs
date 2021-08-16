using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTriggerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject audioSource;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            audioSource.SetActive(true);
        }
    }
}
