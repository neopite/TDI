using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public  class TowerBase : MonoBehaviour , IShootable
    {
        public int level;
        public float cost;
        public EnemyType enemyType; 
        
        public void Shoot(int damage, EnemyBase target)
        {
            if (target != null)
            {
                target.ReceiveDamage(damage);
                Debug.Log("Target :" + target.type + " Receive damage");
            }
        }
        

       
    }
}