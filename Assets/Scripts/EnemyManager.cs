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
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
            }else Destroy(gameObject);
            _towerGridsTowerCells = new List<EnemyCell>();
            _previewEnemyCells = new List<EnemyCell>();
            _towerGridsTowerCells.AddRange(_enemyGrid.CreateGrid());
            _previewEnemyCells.AddRange(_enemyPreviewGrid.CreateGrid());
        }
    }
}