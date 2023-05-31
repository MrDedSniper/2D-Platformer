using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CoinsObjectView : MonoBehaviour
    {
        public SpriteRenderer[] _spriteRenderers;
        public Collider2D[] _colliders;

        [SerializeField] private List<GameObject> _allCoins;

        public List<GameObject> AllCoins
        {
            get => _allCoins;
            set => _allCoins = value;
        }

        private void Awake()
        {
            _allCoins = new List<GameObject>();
        }
    }
}

