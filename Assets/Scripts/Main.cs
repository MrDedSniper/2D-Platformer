using System;
using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private InteractiveObjectView _playerView;
        [SerializeField] private CoinsObjectView _coinsView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private AiConfig _aiConfig;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private CrowView _crowView;
        [SerializeField] private GeneratorLevelView _generatorView;
        [SerializeField] private GeneratorLevelView _msgeneratorView;

        private PlayerController _playerController;
        private CoinsController _coinsController;
        private CannonController _cannonController;
        private EmitterController _emitterController;
        private SimplePatrolAI _simplePatrolAI;
        private GolemController _enemyController;
        private CrowController _crowController;
        private GeneratorController _generatorController;
        private MSGeneratorController _msgeneratorController;
        
        private void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _coinsController = new CoinsController(_coinsView);
            _cannonController = new CannonController(_cannonView._muzzleT, _playerView._transform);
            _emitterController = new EmitterController(_cannonView._bullets, _cannonView._emitterT);
            _simplePatrolAI = new SimplePatrolAI(_enemyView, new SimplePatrolAIModel(_aiConfig));
            _enemyController = new GolemController(_enemyView);
            _crowController = new CrowController(_crowView);
            
            _generatorController = new GeneratorController(_generatorView);
            _generatorController.Start();
            
            _msgeneratorController = new MSGeneratorController(_msgeneratorView);
            _msgeneratorController.Start();
            
        }
        private void Update()
        {
            _playerController.Update();
            _coinsController.Update();
            _cannonController.Update();
            _emitterController.Update();
            _enemyController.Update();
            _crowController.Update();
        }

        private void FixedUpdate()
        {
            _simplePatrolAI.FixedUpdate();
        }
    } 
}

