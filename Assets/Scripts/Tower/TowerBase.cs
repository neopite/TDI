using UnityEngine;

namespace DefaultNamespace
{
    public abstract class TowerBase : MonoBehaviour
    {
        public uint Level;
        public uint Cost;
        public abstract void Shoot();
        
    }
}