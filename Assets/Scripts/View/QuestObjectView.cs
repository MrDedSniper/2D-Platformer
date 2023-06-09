using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{ public class QuestObjectView : LevelObjectView
    {
        public int Id => _id;
        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;
        private Color _defaultColor;
        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }
        
        public void ProcessComplete()
        {
            _spriteRenderer.color = _completedColor;
        }
        
        public void ProcessActivate()
        {
            _spriteRenderer.color = _defaultColor;
        }
        
    }
}

