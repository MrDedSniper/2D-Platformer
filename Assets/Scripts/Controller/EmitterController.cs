using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PlatformerMVC
{
    public class EmitterController
    {
        private List<BulletController> _bulletControllers = new List<BulletController>();
        private Transform _tr;

        private int _index;
        private float _timeTillNextBool;
        private float _startSpeed = 15f;
        private float _delay = 3f;

        public EmitterController(List<BulletView> bulletViews, Transform emitterTr)
        {
            _tr = emitterTr;
            foreach (BulletView bulletView in bulletViews)
            {
                _bulletControllers.Add(new BulletController(bulletView));
            }
        }

        public void Update()
        {
            if (_timeTillNextBool > 0)
            {
                _bulletControllers[_index].Active(false);
                _timeTillNextBool -= Time.deltaTime;
            }

            else
            {
                _timeTillNextBool = _delay;
                _bulletControllers[_index].Trow(_tr.position, -_tr.up * _startSpeed);
                _index++;

                if (_index >= _bulletControllers.Count)
                {
                    _index = 0;
                }
            }
        }
    }
}


