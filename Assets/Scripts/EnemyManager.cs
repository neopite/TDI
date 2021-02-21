using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance;
        public EnemyGrid enemyGrid;
        public EnemyGrid enemyPreviewGrid;
        public List<EnemyCell> towerGridsTowerCells;
        public List<EnemyCell> previewEnemyCells;
        public List<Wave> waves;
        public int replyCountWaves;
        public WaveReward waveReward;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
            }else Destroy(gameObject);

            for (int i = 0; i < replyCountWaves; i++)
            {
                waves.AddRange(waves);
            }
            towerGridsTowerCells = new List<EnemyCell>();
            previewEnemyCells = new List<EnemyCell>();
            towerGridsTowerCells.AddRange(enemyGrid.CreateGrid());
            previewEnemyCells.AddRange(enemyPreviewGrid.CreateGrid());
        }
    }
}