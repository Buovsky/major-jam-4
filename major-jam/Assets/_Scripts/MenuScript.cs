using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private bool isMenuShown;

    [SerializeField] private GameObject overlay;
    [SerializeField] private GameObject fadeIn;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip menuSound;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isMenuShown)
            {
                fadeIn.SetActive(true);
                Invoke("LoadGameplay", 4f);
                audioSource.PlayOneShot(menuSound);
            }
            else
            {
                isMenuShown = true;
                overlay.SetActive(isMenuShown);
                audioSource.PlayOneShot(menuSound);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuShown = false;
            overlay.SetActive(isMenuShown);
            audioSource.PlayOneShot(menuSound);
        }
    }

    void LoadGameplay()
    {
        SceneManager.LoadScene("_LevelScenes/GameplayScenes/Level1");
    }
}