using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class SimplePatrolAI
    {
        private EnemyView _view;
        private SimplePatrolAIModel _model;
    
        public SimplePatrolAI(EnemyView view, SimplePatrolAIModel model)
        {
            _view = view;
            _model = model;
        }

        public void FixedUpdate()
        {
            _view.Rigidbody.velocity = _model.CalculateVelocity(_view.transform.position) * Time.fixedDeltaTime;
        }
    }
}

