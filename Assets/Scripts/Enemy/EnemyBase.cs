using System;
using UnityEngine;

namespace DefaultNamespace.Enemy
{
    public abstract class EnemyBase : MonoBehaviour , IDamageable
    {
        public int Level;
        private int currentHp;
        public EnemyType type;

        private void Start()
        {
            currentHp = Level;
        }

        public void ReceiveDamage(int damage)
        {
            currentHp -= damage;
            if (currentHp <= 0)
            {
                Destroy(gameObject);
            }
        }
        public enum EnemyType
        {
            Circle,Square,Triangle
        }

        public void ChangeStage(Vector2 nextTilePosition)
        {
            gameObject.transform.position = nextTilePosition;
        }
    }
}