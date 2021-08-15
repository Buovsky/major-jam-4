using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _actionText;
    [SerializeField] private PlayerController _playerController;

    public void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void FixedUpdate()
    {
        _actionText.text = _playerController.ActionPoints.ToString();
    }
}
