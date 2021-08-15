using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    [SerializeField] private GameObject _tutorialObj;
    [SerializeField] private Text _tutorialTxt;

    private void Start()
    {
        _tutorialObj.SetActive(false);
    }

    public void Close()
    {
        _tutorialObj.SetActive(false);
    }

    public void Display(string text)
    {
        _tutorialObj.SetActive(true);
        _tutorialTxt.text = text;
    }
}
