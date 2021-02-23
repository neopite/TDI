using System;
using UnityEngine;

namespace DefaultNamespace.Enemy
{
    public class EnemyHpEvents : MonoBehaviour
    {
        public static EnemyHpEvents Instance;
        public Action<EnemyBase> OnChangeCurrentHp;
        public void ChangeCurrentHp(EnemyBase enemyBase)
        {
            OnChangeCurrentHp?.Invoke(enemyBase);
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