using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  PlatformerMVC
{
    public class BackgroundController : MonoBehaviour
    {

        [SerializeField] private Transform _target;
        [SerializeField, Range(0f, 1f)] private float parallaxStrength = 0.1f;
        [SerializeField] private bool _disavleVertParallax;
        private Vector3 _targetPreviousPosition;

        private void Start()
        {
            if (!_target)
            {
                _target = Camera.main.transform;
                _targetPreviousPosition = _target.position;
            }
        }

        private void Update()
        {
            var delta = _target.position - _targetPreviousPosition;

            if (_disavleVertParallax)
            {
                delta.y = 0;
            }

            _targetPreviousPosition = _target.position;
            transform.position += delta * parallaxStrength;
        }
    }
}

