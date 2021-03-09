using System.Collections.Generic;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class Wave
    {
        public List<EnemyBase> ListOfEnemies;
        private List<GameObject> _enemyGridCells;

        public void Move(int stage)
        {
           // _enemyGridCells = EnemyGridManager.Instance._enemyGrid;
            for (int i = 0; i < ListOfEnemies.Count; i++)
            {
              //  ListOfEnemies[i].ChangeStage(stage*EnemyGridManager.Instance._enemyGrid.Columns+i);
            }
        }
    }
    
    [System.Serializable]
    public class WavesList
    {
        public List<Wave> ListOfWaves;
    }
}