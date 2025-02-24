﻿using System;
using DefaultNamespace.Enemy;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public  class TowerBase : MonoBehaviour , IShootable
    {
        [SerializeField]private int level;
        [SerializeField]private float cost;

        public int Level
        {
            get => level;
            set => level = value;
        }

        public float Cost
        {
            get => cost;
            set => cost = value;
        }

        public EnemyType enemyType;
        [SerializeField]private TextMeshProUGUI _levelView;

        private void Start()
        {
            ChangeLevelOnView(this);
            TowerUpgradeEvents.Instance.OnUpgradeTower += ChangeLevelOnView;
        }

        public void Shoot(int damage, EnemyBase target)
        {
            if (target != null)
            {
                target.ReceiveDamage(damage);
                Debug.Log("Target :" + target.type + " Receive damage");
            }
        }
        
        private void ChangeLevelOnView(TowerBase tower)
        {
            tower._levelView.text = tower.level.ToString();
        }
    }
}