using System;
using UnityEngine;

namespace DefaultNamespace.Interaction
{
    public class UpgradeTower : Interactable
    {
        [SerializeField][Range(0,300)]private int _percentUpPerUpgrade;
        private TowerBase _tower;

        public void Start()
        {
            _tower = GetComponent <TowerBase>();
        }
        public override void Interact()
        {
            float newTowerCost = _percentUpPerUpgrade * _tower.cost  / 100 + _tower.cost;
            if(PlayerData.Instance.IsEnoughMoney(newTowerCost))
            {
                MoneyEvents.Instance.ChangePlayerMoney(-newTowerCost);
                _tower.cost = newTowerCost;
                _tower.level++;
                TowerUpgradeEvents.Instance.UpgradeTower(_tower);
            }
        }
    }
}