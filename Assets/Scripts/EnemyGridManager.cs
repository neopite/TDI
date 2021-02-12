using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyGridManager : MonoBehaviour
    {
        public static EnemyGridManager Instance;
        public Grid _enemyGrid;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }else Destroy(gameObject);
            _enemyGrid.CreateGrid();
        }
    }
}