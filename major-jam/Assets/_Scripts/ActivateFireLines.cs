using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFireLines : MonoBehaviour
{
    public GameObject fireLine_0;
    public GameObject fireLine_1;
    public GameObject fireLine_2;
    public GameObject fireLine_3;
    public GameObject fireLine_4;
    public GameObject fireLine_5;
    public GameObject fireLine_6;
    public GameObject fireLine_7;

    [SerializeField] private float timeToFire0 = 2f;
    [SerializeField] private float timeToFire1 = 5f;
    [SerializeField] private float timeToFire2 = 8f;
    [SerializeField] private float timeToFire3 = 10f;
    [SerializeField] private float timeToFire4 = 12f;
    [SerializeField] private float timeToFire5 = 14f;
    [SerializeField] private float timeToFire6 = 16f;
    [SerializeField] private float timeToFire7 = 18f;
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("Player"))
        {
            ActivateAllFireLines();
            Debug.Log("COLLISION ACTIVATED");
        }
    }

    void ActivateAllFireLines()
    {
            Invoke("ActivateFireLine_0", timeToFire0);
            Invoke("ActivateFireLine_1", timeToFire1);
            Invoke("ActivateFireLine_2", timeToFire2);
            Invoke("ActivateFireLine_3", timeToFire3);
            Invoke("ActivateFireLine_4", timeToFire4);
            Invoke("ActivateFireLine_5", timeToFire5);
            Invoke("ActivateFireLine_6", timeToFire6);
            Invoke("ActivateFireLine_7", timeToFire7);
    }

    void ActivateFireLine_0()
    {
        fireLine_0.SetActive(true);
    }
    void ActivateFireLine_1()
    {
        fireLine_1.SetActive(true);
    }
    void ActivateFireLine_2()
    {
        fireLine_2.SetActive(true);
    }
    void ActivateFireLine_3()
    {
        fireLine_3.SetActive(true);
    }
    void ActivateFireLine_4()
    {
        fireLine_4.SetActive(true);
    }
    void ActivateFireLine_5()
    {
        fireLine_5.SetActive(true);
    }
    void ActivateFireLine_6()
    {
        fireLine_6.SetActive(true);
    }
    void ActivateFireLine_7()
    {
        fireLine_7.SetActive(true);
    }
}
