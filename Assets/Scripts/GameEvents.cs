using System;
using System.Collections.Generic;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents Instance;

        public Action<GameObject> OnDestroyEnemyByGettingTarget;
        public List<EnemyBase> ListOfEnemy;

        public void DestroyEnemyByGettingTarget(GameObject enemy)
        {
            if (OnDestroyEnemyByGettingTarget != null)
            {
                OnDestroyEnemyByGettingTarget(enemy);
            }
        }
        



        public void Start()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else Instance = this;
        }
        
    }
}