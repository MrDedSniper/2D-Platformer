using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class GolemController
    {
        private ContactPooler _contactPooler;
        
        private SpriteAnimatorController _enemyAnimator;
        private AnimationConfig _config;
        private EnemyView _enemyView;
        
        [SerializeField] private Transform _golemTransform;
        private Transform _targetTransform;

        private float _animationSpeed = 10f;

        public GolemController(EnemyView golem)
        {
            _enemyView = golem;
            
            GameObject player = GameObject.FindWithTag("Player");

            /*_golemTransform = golem._transform;
            _targetTransform = golem._target;*/
            
            
            _config = Resources.Load<AnimationConfig>("GolemCfg");
            _enemyAnimator = new SpriteAnimatorController(_config);
            
            foreach (SpriteRenderer renderer in _enemyView._spriteRenderers)
            {
                _enemyAnimator.StartAnimation(renderer, AnimState.Idle, true, _animationSpeed); 
            }
            
            _contactPooler = new ContactPooler(_enemyView._colliders[0]);

        }

        public void Update()
        {
            _enemyAnimator.Update();
            _contactPooler.Update();

            /*if (_targetTransform.transform.position.x < _golemTransform.position.x)
            {
                foreach (SpriteRenderer renderer in _enemyView._spriteRenderers)
                {
                    _enemyView._spriteRenderers[0].flipX = false;
                }
                
            }
            else if (_targetTransform.transform.position.x > _golemTransform.position.x)
            {
                _enemyView._spriteRenderers[0].flipX = true;
            }*/
        }
        
        private void MoveTowards()
        {
            
        }
    }
}

