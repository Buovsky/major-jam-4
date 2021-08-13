using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    [SerializeField] private GameObject _terminal;
    [SerializeField] private InputField _field;
    [SerializeField] private Text _stdout;
    
    void Start()
    {
        _terminal.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!_terminal.gameObject.activeSelf && Input.GetKeyDown(KeyCode.BackQuote))
        {
            _terminal.gameObject.SetActive(true);
            _field.Select();
            _field.ActivateInputField();
        }
        
        if (_terminal.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape)) _terminal.gameObject.SetActive(false);
        
        if (_field.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            ProcessCode(_field.text);
            _field.text = "";
            _field.Select();
            _field.ActivateInputField();
        }
    }
    
    private void ProcessCode(string code)
    {
        string normalizedCode = code.Trim();
        if (normalizedCode.Length == 0) return;

        string[] command = normalizedCode.Split(' ');

        if (command[0] == "pwd")
            WriteOutput("/home/janosik/");
        else if (command[0] == "ls")
            WriteOutput("boney_m-rasputin.mp3\nbig_day-wdzien_goraceg_lata_hit.mp3");
        else if (command[0] == "help")
            WriteOutput("Broken command, search for floppy disks to recover data...");
        else if (command[0] == "git" && command[1] == "push")
            WriteOutput("I hate push ups lol...");
        else
            WriteOutput("Unknown command");
    }

    public void WriteOutput(string text)
    {
        _stdout.text = text;
    }
}
