using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TowerUpgradeEvents : MonoBehaviour
    {
        public static TowerUpgradeEvents Instance;
        public Action<TowerBase> OnUpgradeTower;

        public void UpgradeTower(TowerBase towerBase)
        {
            OnUpgradeTower?.Invoke(towerBase);
        }

        public void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }else Destroy(this);
        }
    }
}