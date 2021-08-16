using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerController : MonoBehaviour
{
    public string nextSceneName;
    public GameObject fadeIn;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            fadeIn.SetActive(true);
            Invoke("LoadGameplay", 4f);
        }
    }

    void LoadGameplay()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
