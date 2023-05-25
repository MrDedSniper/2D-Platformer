using System;
using System.Collections;
using System.Collections.Generic;
using PlatformerMVC;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    [SerializeField] private EnemyView _enemyView;
    
    private AiConfig _config;
    private SimplePatrolAI _simplePatrolAI;

    private void Start()
    {
        _simplePatrolAI = new SimplePatrolAI(_enemyView, new SimplePatrolAIModel(_config));
    }

    private void FixedUpdate()
    {
        _simplePatrolAI.FixedUpdate();
    }
}
