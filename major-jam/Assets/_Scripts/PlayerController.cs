using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Scene currentScene;
    public float moveSpeed = 5f;
    public Transform movePoint;

    public enum JanosikForms{Walk, Ghost, Hover, Slime}
    public JanosikForms currentForm;
    public LayerMask wall;
    void Start()
    {
        movePoint.parent = null;
        currentForm = JanosikForms.Walk;
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 0f)
            {
                if(currentForm != JanosikForms.Ghost)
                {
                    if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .1f, wall))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                }
                else
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }      

            }

            if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 0f)
            {
                if(currentForm != JanosikForms.Ghost)
                {
                   if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .1f, wall))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    } 
                }
                else
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        switch(currentForm)
        {
            case JanosikForms.Walk:
                if(other.tag == "Fire" || other.tag == "Hole")
                {
                    SceneManager.LoadScene(currentScene.name);
                }
                break;

            case JanosikForms.Ghost:
            {
                if(other.tag == "Fire" || other.tag == "Hole")
                {
                    SceneManager.LoadScene(currentScene.name);
                }
                break;
            }

            case JanosikForms.Hover:
            {
                if(other.tag == "Fire")
                {
                    SceneManager.LoadScene(currentScene.name);
                }
                break;
            }

            case JanosikForms.Slime:
            {
                if(other.tag == "Hole")
                {
                    SceneManager.LoadScene(currentScene.name);
                }
                break;
            }

            default:
                Debug.Log("No form");
                break;
        }
    }
    
}
