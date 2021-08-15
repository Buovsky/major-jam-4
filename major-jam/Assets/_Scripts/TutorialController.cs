using System;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
        private Tutorial _tutorial;
        public string Text;
        
        private void Start()
        {
                _tutorial = FindObjectOfType<Tutorial>();
        }

        private void OnTriggerEnter(Collider other)
        {
                if (other.gameObject.CompareTag("Player"))
                {
                        _tutorial.Display(Text);
                }
        }

        private void OnTriggerExit(Collider other)
        {
                if (other.gameObject.CompareTag("Player"))
                {
                        _tutorial.Close();
                }
        }
}