using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class TowerBase : MonoBehaviour , IShootable
    {
        public uint Level;
        public uint Cost;
        public abstract void Shoot(int damage, EnemyBase target);
    }
}