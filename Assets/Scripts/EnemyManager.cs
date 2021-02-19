using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance;
        public EnemyGrid _enemyGrid;
        public EnemyGrid _enemyPreviewGrid;
        public List<EnemyCell> _towerGridsTowerCells;
        public List<EnemyCell> _previewEnemyCells;
        public List<Wave> Waves;
        public int ReplyCountWaves;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
            }else Destroy(gameObject);

            for (int itter = 0; itter < ReplyCountWaves; itter++)
            {
                Waves.AddRange(Waves);
            }
            _towerGridsTowerCells = new List<EnemyCell>();
            _previewEnemyCells = new List<EnemyCell>();
            _towerGridsTowerCells.AddRange(_enemyGrid.CreateGrid());
            _previewEnemyCells.AddRange(_enemyPreviewGrid.CreateGrid());
        }
    }
}