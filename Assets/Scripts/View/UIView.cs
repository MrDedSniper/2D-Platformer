using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformerMVC
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private Text _textCoinsCount;
        [SerializeField] private Text _textLifeCount;

        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            _textCoinsCount.text = _gameManager.CoinsCount + " / " + _gameManager.MaxCoinOnLevel;
            _textLifeCount.text = "x " + _gameManager.LifeCount;
        }
    }
}

