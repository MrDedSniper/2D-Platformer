using UnityEngine;

namespace PlatformerMVC
{
    public class CoinsController
    {
        private ContactPooler _contactPooler;
        
        private SpriteAnimatorController _coinAnimator;
        private AnimationConfig _config;
        private CoinsObjectView _coinView;

        private float _animationSpeed = 10f;

        public CoinsController(CoinsObjectView coin)
        {
            _coinView = coin;
            
            _config = Resources.Load<AnimationConfig>("CoinsCfg");
            _coinAnimator = new SpriteAnimatorController(_config);
            
            foreach (SpriteRenderer renderer in _coinView._spriteRenderers)
            {
                _coinAnimator.StartAnimation(renderer, AnimState.Idle, true, _animationSpeed);
            }
            
            _contactPooler = new ContactPooler(_coinView._colliders[0]);
        }

        public void Update()
        {
            _coinAnimator.Update();
            _contactPooler.Update();

            if (_contactPooler.isTouched)
            {
                _coinView.gameObject.SetActive(false);
            }
        }
    }
}

