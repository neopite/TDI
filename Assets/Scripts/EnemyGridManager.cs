using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyGridManager : MonoBehaviour
    {
        public static EnemyGridManager Instance;
        public Grid _enemyGrid;
        public Grid _enemyPreviewGrid;
        public List<TowerGridCell> _towerGridsTowerCells;
        public List<TowerGridCell> _previewEnemyCells;
        public WavesList ListOfWaves = new WavesList();
        //public List<Wave> InitedWaves;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
            }else Destroy(gameObject);
            _towerGridsTowerCells = new List<TowerGridCell>();
            _previewEnemyCells = new List<TowerGridCell>();
            _towerGridsTowerCells.AddRange(_enemyGrid.CreateGrid());
            _previewEnemyCells.AddRange(_enemyPreviewGrid.CreateGrid());
        }
    }
}