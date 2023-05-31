using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformerMVC
{
    public class RestartGame : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = GameObject.FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Reset();
            }
        }

        public void Reset()
        {
            _gameManager.Death();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

