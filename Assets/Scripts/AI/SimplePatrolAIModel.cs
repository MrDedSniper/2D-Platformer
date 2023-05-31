using UnityEngine;

namespace PlatformerMVC
{
    public class SimplePatrolAIModel : MonoBehaviour
    {
        private AiConfig _config;
        public Transform _target;
        private int _currentPointIndex;
    
        public SimplePatrolAIModel(AiConfig config)
        {
            _config = config;
            _target = GetNextWaypoint();
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var distance = Vector2.Distance(_target.position, fromPosition);

            if (distance <= _config.MinDistanceToTarget)
            {
                _target = GetNextWaypoint();
            }

            var direction = ((Vector2) _target.position - fromPosition).normalized;
        
            return _config.Speed * direction;
        }
        private Transform GetNextWaypoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.Waypoints.Length;
            return _config.Waypoints[_currentPointIndex];
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _target = other.transform;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _target = GetNextWaypoint();
            }
        }

    }
}

