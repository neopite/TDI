using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class IncreaseLevelBuff 
    {
        [SerializeField] private int levelIncrease;
        [SerializeField] private EnemyType enemyType;
        [SerializeField] private int anotherLevelIncrease;
        public void CastBuff(ref EnemyBase target)
        {
            if (enemyType == target.type)
            {
                target.level += levelIncrease;
            }
            else target.level += anotherLevelIncrease;
        }
    }
}