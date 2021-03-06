using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Scene _currentScene;
    private Terminal _terminal;
    private LevelController _levelController;
    
    public float MoveSpeed = 5f;
    public Transform MovePoint;
    public int ActionPoints;
    public int MoveDistance = 1;

    public enum JanosikForms
    {
        Walk,
        Ghost,
        Hover,
        Slime
    }

    public JanosikForms CurrentForm;
    public LayerMask Wall;

    public GameObject defaultSprite;
    public GameObject hoverSprite;
    public GameObject ghostSprite;
    public GameObject slimeSprite;

    private void Start()
    {
        MovePoint.parent = null;
        CurrentForm = JanosikForms.Walk;
        _currentScene = SceneManager.GetActiveScene();
        _terminal = FindObjectOfType<Terminal>();
        _levelController = FindObjectOfType<LevelController>();
        ActionPoints = _levelController.ActionPoints;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, MoveSpeed * Time.deltaTime);

        if (_terminal.IsVisible) return;
        
        if (Vector3.Distance(transform.position, MovePoint.position) <= .05f)
        {
            
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow))
            {
                for (int i = 0; i < MoveDistance; i++)
                {
                    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f &&
                        Mathf.Abs(Input.GetAxisRaw("Vertical")) == 0f)
                    {
                        if (CurrentForm != JanosikForms.Ghost)
                        {
                            if (!Physics2D.OverlapCircle(
                                MovePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .1f, Wall))
                                MovePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        }
                        else
                        {
                            MovePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        }
                    }

                    if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f &&
                        Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 0f)
                    {
                        if (CurrentForm != JanosikForms.Ghost)
                        {
                            if (!Physics2D.OverlapCircle(
                                MovePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f),
                                .1f, Wall)) MovePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        }
                        else
                        {
                            MovePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        }
                    }
                }

                ActionPoints--;
                if(ActionPoints == -1) SceneManager.LoadScene(_currentScene.name);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (CurrentForm)
        {
            case JanosikForms.Walk:
            case JanosikForms.Ghost:
                if (other.CompareTag("Fire") || other.CompareTag("Hole")) SceneManager.LoadScene(_currentScene.name);
                break;

            case JanosikForms.Hover:
            {
                if (other.CompareTag("Fire")) SceneManager.LoadScene(_currentScene.name);
                break;
            }

            case JanosikForms.Slime:
            {
                if (other.CompareTag("Hole")) SceneManager.LoadScene(_currentScene.name);
                break;
            }

            default:
                Debug.Log("No form");
                break;
        }
    }

    public void SetJanosikForm(string form)
    {
        CurrentForm = form switch
        {
            "walk" => JanosikForms.Walk,
            "passing_through" => JanosikForms.Ghost,
            "hover" => JanosikForms.Hover,
            "slime_on" => JanosikForms.Slime,
            _ => CurrentForm
        };

        if(CurrentForm == JanosikForms.Walk)
        {
            gameObject.tag = "Player";
        }
        else
        {
            gameObject.tag = "PlayerNotWalk";
        }

                switch (CurrentForm)
        {
            case JanosikForms.Walk:
                defaultSprite.SetActive(true);
                hoverSprite.SetActive(false);
                ghostSprite.SetActive(false);
                slimeSprite.SetActive(false);
                break;

            case JanosikForms.Ghost:
                defaultSprite.SetActive(false);
                ghostSprite.SetActive(true);
                hoverSprite.SetActive(false);
                slimeSprite.SetActive(false);
                break;
                
            case JanosikForms.Hover:
            {
                defaultSprite.SetActive(false);
                ghostSprite.SetActive(false);
                hoverSprite.SetActive(true);
                slimeSprite.SetActive(false);
                break;
            }

            case JanosikForms.Slime:
            {
                defaultSprite.SetActive(false);
                ghostSprite.SetActive(false);
                hoverSprite.SetActive(false);
                slimeSprite.SetActive(true);
                break;
            }

            default:
                Debug.Log("No form");
                break;
        }
    }

    public void TeleportTo(int x, int y)
    {
        float ax = -8.5f + x;
        float ay = 4.5f - y;

        transform.position = new Vector3(ax, ay, 0);
        MovePoint.transform.position = transform.position;
    }
}