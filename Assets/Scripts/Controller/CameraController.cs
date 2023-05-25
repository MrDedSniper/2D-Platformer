using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CameraController : MonoBehaviour
    {
        public Transform playerView;

        private float _smoothness = 1f;

        public void Update()
        {
            Vector3 targetPosition = new Vector3(playerView.transform.position.x, 0, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothness);
        }
    }
}

