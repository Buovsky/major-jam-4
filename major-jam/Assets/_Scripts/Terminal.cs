using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Terminal : MonoBehaviour
{
    [SerializeField] private GameObject _terminal;
    [SerializeField] private InputField _field;
    [SerializeField] private Text _stdout;
    [SerializeField] private PlayerController _playerController;
    private List<string> _codeHistory = new List<string>();
    private int _listCounter = 0;

    public bool IsVisible; 

    
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _terminal.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!_terminal.gameObject.activeSelf && Input.GetKeyDown(KeyCode.BackQuote))
        {
            _listCounter = 0;
            _terminal.gameObject.SetActive(true);
            _field.Select();
            _field.ActivateInputField();
            _field.text = "";
            IsVisible = true;
        }

        if (_terminal.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            _terminal.gameObject.SetActive(false);
            IsVisible = false;
        }
        
        if (_field.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            _codeHistory.Add(_field.text);
            ProcessCode(_field.text);
            _field.text = "";
            _field.Select();
            _field.ActivateInputField();
        }
        
        if (_field.gameObject.activeSelf && _codeHistory.Count > 0 && Input.GetKeyDown(KeyCode.UpArrow))
        {

            if(_listCounter <= _codeHistory.Count - 1)
            {
                _listCounter++;                
            
                Debug.Log(_listCounter);
                _field.text = _codeHistory[_codeHistory.Count - _listCounter];
            }
            _field.MoveTextEnd(false);
            
        }

        if (_field.gameObject.activeSelf && _codeHistory.Count > 0 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(_listCounter > 1)
            {
                _listCounter--;
            
                Debug.Log(_listCounter);
                _field.text = _codeHistory[_codeHistory.Count - _listCounter];
            }
            _field.MoveTextEnd(false);
            
        }
    }
    
    private void ProcessCode(string code)
    {
        string normalizedCode = code.Trim();
        if (normalizedCode.Length == 0) return;

        string[] command = normalizedCode.ToLower().Split(' ');
        
        if (command[0] == "pwd")
            WriteOutput("/home/janosik/");
        else if (command[0] == "ls")
            WriteOutput("boney_m-rasputin.mp3\nbig_day-wdzien_goraceg_lata_hit.mp3");
        else if (command[0] == "help")
            WriteOutput("Broken command, search for floppy disks to recover data...");
        else if (command[0] == "git" && command[1] == "push")
            WriteOutput("I hate push ups lol...");
        else if (command.Length == 2 && command[0] == "set_on_move")
        {
            WriteOutput("Setting mode to: " + command[1]);
            _playerController.SetJanosikForm(command[1]);
        }
        else if (command.Length == 2 && command[0] == "set_ap")
        {
            _playerController.ActionPoints = Convert.ToInt16(command[1]);

            WriteOutput("Hacking action points... ");
        }
        else if (command.Length == 2 && command[0] == "set_move_distance")
        {
            WriteOutput("Overriding move distance with value=" + command[1]);
            _playerController.MoveDistance = Convert.ToInt16(command[1]);
        }
        else if (command.Length == 3 && command[0] == "tp_player_to")
        {
            _playerController.TeleportTo(Convert.ToInt16(command[1]), Convert.ToInt16(command[2]));
            WriteOutput("Teleporting to (" + Convert.ToInt16(command[1] + ", " + Convert.ToInt16(command[2]) + ")"));
        }
        else
            WriteOutput("Unknown command");
    }

    private void WriteOutput(string text)
    {
        _stdout.text = text;
    }
}
