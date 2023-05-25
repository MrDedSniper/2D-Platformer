using UnityEngine;

namespace PlatformerMVC
{
    public class PlayerController
    {
        private ContactPooler _contactPooler;
        
        private SpriteAnimatorController _playerAnimator;
        private AnimationConfig _config;
        private LevelObjectView _playerView;

        private Transform _playerTransform;
        private Rigidbody2D _rigidbody;
        
        private bool _isJump;
        
        private float _walkSpeed = 150f;
        private float _animationSpeed = 10f;
        private float _movingTreshold = 0.1f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private bool _isMoving;
        private int _health = 100;

        private float _jumpForce = 9f;
        private float _jumpTreshold = 1f;
        
        private float _yVelocity = 0;
        private float _xVelocity = 0;
        private float _xAxisInput;

        public PlayerController(InteractiveObjectView player)
        {
            _playerView = player;
            _playerTransform = player._transform;
            _rigidbody = _playerView._rb;
            
            _config = Resources.Load<AnimationConfig>("AnimCfg");
            _playerAnimator = new SpriteAnimatorController(_config);
            _playerAnimator.StartAnimation(player._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            
            _contactPooler = new ContactPooler(_playerView._collider);

            player.TakeDamage += TakeBullet;
        }

        private void TakeBullet(BulletView bullet)
        {
            _health -= bullet.DamagePoint;
        }

        private void MoveTowards()
        {
            _xVelocity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
            _rigidbody.velocity = new Vector2(_xVelocity, _yVelocity);
            _playerTransform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }

        public void Update()
        {
            if (_health <= 0)
            {
                _health = 0;
                _playerView._spriteRenderer.enabled = false;
            }
            
            _playerAnimator.Update();
            _contactPooler.Update();
            
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _yVelocity = _rigidbody.velocity.y;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;
            
            _playerAnimator.StartAnimation(_playerView._spriteRenderer, _isMoving?AnimState.Run:AnimState.Idle, true, _animationSpeed);

            if (_isMoving)
            {
                MoveTowards();
            }

            else
            {
                _xVelocity = 0;
                _rigidbody.velocity = new Vector2(_xVelocity, _rigidbody.velocity.y);
            }

            if (_contactPooler.isGrounded)
            {
                if (_isJump && _yVelocity <= _jumpTreshold)
                {
                    _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
            }
            
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpTreshold)
                {
                    _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }
            }
        }
    }
}