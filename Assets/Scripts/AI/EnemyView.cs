using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class EnemyView : MonoBehaviour
    {
        public SpriteRenderer[] _spriteRenderers;
        public Collider2D[] _colliders;
        
        [SerializeField] private Rigidbody2D _rigidbody;

        public Rigidbody2D Rigidbody => _rigidbody;

    }
}


