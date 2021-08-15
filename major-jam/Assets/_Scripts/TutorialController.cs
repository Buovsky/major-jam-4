using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{

    [SerializeField] private GameObject _tutorialObj;
    [SerializeField] private Text _tutorialTxt;

    private void Start()
    {
        _tutorialObj.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _tutorialObj.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _tutorialObj.SetActive(false);
        }
        
    }
}
