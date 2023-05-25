using UnityEngine;

namespace PlatformerMVC
{
    public class CrowController
    {
        private ContactPooler _contactPooler;
        
        private SpriteAnimatorController _crowAnimator;
        private AnimationConfig _config;
        private CrowView _crowView;
        
        private Transform _crownTransform;
        private Transform _targetTransform;

        private float _animationSpeed = 10f;

        public CrowController(CrowView crow)
        {
            _crowView = crow;
            
            GameObject player = GameObject.FindWithTag("Player");

            _crownTransform = crow._transform;
            _targetTransform = crow._target;
            
            
            _config = Resources.Load<AnimationConfig>("CrowCfg");
            _crowAnimator = new SpriteAnimatorController(_config);
            
            foreach (SpriteRenderer renderer in _crowView._spriteRenderers)
            {
                _crowAnimator.StartAnimation(renderer, AnimState.Idle, true, _animationSpeed); 
            }
            
            _contactPooler = new ContactPooler(_crowView._colliders[0]);

        }

        public void Update()
        {
            _crowAnimator.Update();
            _contactPooler.Update();
            
            if (_targetTransform.transform.position.x < _crownTransform.position.x)
            {
                foreach (SpriteRenderer renderer in _crowView._spriteRenderers)
                {
                    _crowView._spriteRenderers[0].flipX = false;
                }
                
            }
            else if (_targetTransform.transform.position.x > _crownTransform.position.x)
            {
                _crowView._spriteRenderers[0].flipX = true;
            }
        }
    }
}

