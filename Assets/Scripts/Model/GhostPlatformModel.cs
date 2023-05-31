using UnityEngine;

namespace PlatformerMVC
{
    public class GhostPlatformModel : MonoBehaviour
    {
        [SerializeField] private GameObject[] _ghostPlatforms;
        private void Awake()
        {
            GhostActive();
        }
        public void GhostActive()
        {
            foreach (var platforms in _ghostPlatforms)
            {
                platforms.GetComponent<BoxCollider2D>().isTrigger = true;

                foreach (Transform child in platforms.transform)
                {
                    SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
                    if (renderer != null)
                    {
                        Color color = renderer.color;
                        color.a = 0.5f;
                        renderer.color = color;
                    }
                }
            }
        }
        public void GhostDeactivate()
        {
            if (_ghostPlatforms == null) Debug.Log("Платформ нет");
            
            else
            {
                foreach (var platforms in _ghostPlatforms)
                {
                    platforms.GetComponent<BoxCollider2D>().isTrigger = false;

                   foreach (Transform child in platforms.transform)
                    {
                        SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
                        if (renderer != null)
                        {
                            Color color = renderer.color;
                            color.a = 1f;
                            renderer.color = color;
                        }
                    }
                }
            }
        }
    }
}

