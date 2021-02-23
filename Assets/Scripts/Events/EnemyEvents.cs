using System;
using System.Collections.Generic;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyEvents : MonoBehaviour
    {
        public static EnemyEvents Instance;
        public Action<GameObject> OnDestroyEnemyByGettingTarget;
        public List<EnemyBase> listOfEnemy;

        public void DestroyEnemyByGettingTarget(GameObject enemy)
        {
            OnDestroyEnemyByGettingTarget?.Invoke(enemy);
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