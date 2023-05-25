using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CrowView : MonoBehaviour
    {
        public SpriteRenderer[] _spriteRenderers;
        public Collider2D[] _colliders;
        
        public Transform _transform;
        public Transform _target;
    }
}


