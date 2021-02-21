using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TowerUpgradeEvents : MonoBehaviour
    {
        public static TowerUpgradeEvents Instance;
        public Action<int> OnUpgradeTower;

        public void UpgradeTower(int newLevel)
        {
            OnUpgradeTower?.Invoke(newLevel);
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