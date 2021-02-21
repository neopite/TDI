using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TowerUpgradeEvents : MonoBehaviour
    {
        public static TowerUpgradeEvents Instance;
        public Action OnUpgradeTower;

        public void UpgradeTower()
        {
            OnUpgradeTower?.Invoke();
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