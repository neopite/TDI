using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance;
        
        [SerializeField]private EnemyGrid _enemyGrid;
        [SerializeField]private EnemyGrid enemyPreviewGrid;
        [SerializeField]private List<EnemyCell> towerGridsTowerCells;
        [SerializeField]private List<EnemyCell> previewEnemyCells;
        [SerializeField]private List<Wave> waves;
        [SerializeField]private int replyCountWaves;
        [SerializeField]private WaveReward waveReward;
        
        public List<EnemyCell> TowerGridsTowerCells => towerGridsTowerCells;
        public List<Wave> LevelWaves => waves;
        public EnemyGrid EnemyGrid => _enemyGrid;
        public WaveReward WaveReward => waveReward;
        private EnemyBuffWave _enemyBuffWave;
        private int _initSize;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
            }else Destroy(gameObject);
            _enemyBuffWave = GetComponent<EnemyBuffWave>();
            _initSize = waves.Count;
            int col = _enemyGrid.Columns;
            for (int i = 1; i <replyCountWaves; i++) 
            {
                waves.AddRange(waves);
            }
            towerGridsTowerCells = new List<EnemyCell>();
            previewEnemyCells = new List<EnemyCell>();
            towerGridsTowerCells.AddRange(_enemyGrid.CreateGrid());
            previewEnemyCells.AddRange(enemyPreviewGrid.CreateGrid());
        }

        public List<EnemyBase> InstantiateWave(List<EnemyBase> listOfEnemies,int wavesSpawned)
        {
            List<EnemyBase> createdEnemies = new List<EnemyBase>();
            for (int i = 0; i < listOfEnemies.Count; i++) 
            {
                EnemyBase enemy = Instantiate(listOfEnemies[i], transform);
                enemy.transform.position = previewEnemyCells[i].transform.position;
                enemy.ColumnId = i; // set enemy column by default
                for (int j = 1; j < wavesSpawned/_initSize; j++)
                {
                    _enemyBuffWave.listOfBuffs[i].CastBuff(ref enemy);   
                }
                enemy.ChangeLevel(enemy.Level);
                createdEnemies.Add(enemy);
            }

            return createdEnemies;
        }
    }
}