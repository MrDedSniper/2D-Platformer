using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PlatformerMVC
{
    public class ContactPooler : MonoBehaviour
    {
        private Collider2D _collider;
        private ContactPoint2D[] _contactPoint = new ContactPoint2D[5];
        private int _contactCount = 0;
        private float _treshold = 0.2f;
        
        public bool isGrounded { get; private set; }
        public bool isLeftContact { get; private set; }
        public bool isRightContact { get; private set; }
        public bool isTouched { get; private set; }
        
        public ContactPooler(Collider2D collider)
        {
            _collider = collider;
        }
        public void Update()
        {
            isGrounded = false;
            isLeftContact = false;
            isRightContact = false;
            isTouched = false;

            _contactCount = _collider.GetContacts(_contactPoint);

            for (int i = 0; i < _contactCount; i++)
            {
                if (_contactPoint[i].normal.y > _treshold) isGrounded = true;
                if (_contactPoint[i].normal.x > _treshold) isLeftContact = true;
                if (_contactPoint[i].normal.x < -_treshold) isRightContact = true;
                if (_contactPoint[i].normal.x > 0 || _contactPoint[i].normal.y > 0) isTouched = true;
            }
        }
    } 
}

