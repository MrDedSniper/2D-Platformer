using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _winText;
        [SerializeField] private GameObject _loseText;

        private RestartGame _restartGame;
        
        private int _coinsCount = 0;
        private int _lifeCount = 3;
        private int _maxCoinOnLevel = 9;

        private void Awake()
        {
            _restartGame = FindObjectOfType<RestartGame>();
            _winText.gameObject.SetActive(false);
            _loseText.gameObject.SetActive(false);
        }

        private void StartParams()
        {
            _coinsCount = 0;
            _lifeCount = 3;
            _maxCoinOnLevel = 9;
        }


        public void CollectCoin()
        {
            _coinsCount++;

            if (_coinsCount >= _maxCoinOnLevel)
            {
                Win();
            }
        }
        
        public void Death()
        {
            _lifeCount--;

            if (_lifeCount <= 0)
            {
                Lose();
            }
        }

        public void Win()
        {
            Time.timeScale = 0f;
            //_winText.SetActive(true);
            
            if (Input.anyKey)
            {
                //StartParams();
                _restartGame.Reset();
            }
        }

        public void Lose()
        {
            Time.timeScale = 0f;
            //_loseText.SetActive(true);

            if (Input.anyKey)
            {
               //StartParams();
                _restartGame.Reset();
            }
        }
        
        public int CoinsCount
        {
            get => _coinsCount;
        }

        public int LifeCount
        {
            get => _lifeCount;
        }

        public int MaxCoinOnLevel => _maxCoinOnLevel;
    }
}

