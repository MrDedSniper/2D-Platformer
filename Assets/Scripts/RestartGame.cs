using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformerMVC
{
    public class RestartGame : MonoBehaviour
    {
        //private PlayerController _player;

        /* public RestartGame(PlayerController player)
         {
             _player = player;
         }*/
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}

