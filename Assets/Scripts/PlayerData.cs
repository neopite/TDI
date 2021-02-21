using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerData : MonoBehaviour
    {
        public static PlayerData Instance;
        [SerializeField]private  float _currentMoney;
        [SerializeField]private  int _currentScore;
        private PlayerInfoView _playerInfo;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }else Destroy(Instance);

            _playerInfo = GetComponent<PlayerInfoView>();
            _playerInfo.money.text = _currentMoney.ToString();
            _playerInfo.score.text = _currentScore.ToString();
            MoneyEvents.Instance.OnChangePlayerMoney += ChangeMoney;
            ScoreEvents.Instance.OnChangeScore += ChangeScore;
        }

        private void ChangeMoney(float money)
        {
            _currentMoney = _currentMoney + money;
            _playerInfo.money.text = _currentMoney.ToString();
        }

        private void ChangeScore(int score)
        {
            _currentScore = _currentScore + score;
            _playerInfo.score.text = _currentScore.ToString();
        }

        public bool IsEnoughMoney(float towerCost)
        {
            return towerCost <= _currentMoney;
        }
    }
}