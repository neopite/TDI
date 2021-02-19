using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class TowerBase : MonoBehaviour , IShootable
    {
        public int Level;
        public uint Cost;
        public abstract void Shoot(int damage, EnemyBase target);

        public void Update()
        {
            
        }
    }
}