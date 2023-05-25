using System;
using UnityEngine;

namespace PlatformerMVC
{
    public class InteractiveObjectView : LevelObjectView
    {
        public Action<BulletView> TakeDamage { get; set; }
        private void OnTriggerEnter(Collider2D other)
        {
            if (other.TryGetComponent(out BulletView contactView))
            {
                TakeDamage?.Invoke(contactView);
            }
        }
    }
}

