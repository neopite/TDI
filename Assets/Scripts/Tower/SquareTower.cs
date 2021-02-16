using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class SquareTower : TowerBase
    {
        public override void Shoot(int damage, EnemyBase target)
        {
            if (target != null)
            {
                target.ReceiveDamage(damage);
                Debug.Log("Target :" + target.type + " Receive damage");
            }
        }
    }
}