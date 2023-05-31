using System;
using UnityEngine;

namespace PlatformerMVC
{
    public class InteractiveObjectView : LevelObjectView
    {
        public Action<BulletView> TakeDamage { get; set; }
        public Action<QuestObjectView> OnComplete { get; set; }

        //public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        public bool _isDeathDamage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out LevelObjectView contactView))
            {
                
                if(contactView is QuestObjectView)
                {
                    OnComplete?.Invoke((QuestObjectView)contactView);
                }

                if (contactView is BulletView)
                {
                    TakeDamage?.Invoke((BulletView)contactView);
                }
            }

            if (collision.gameObject.tag == "DeathZone")
            {
                _isDeathDamage = true;
            }
        }
    }
}

