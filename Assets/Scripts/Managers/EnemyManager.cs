using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Enemy;
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
        private EnemyBuffWave _enemyBuffWave;
        private int initSize;
        private int cycles;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
            }else Destroy(gameObject);
            _enemyBuffWave = GetComponent<EnemyBuffWave>();
            initSize = waves.Count;
            cycles = 0;
            int col = enemyGrid.Columns;
            for (int i = 1; i <replyCountWaves; i++) 
            {
                waves.AddRange(waves);
            }
            towerGridsTowerCells = new List<EnemyCell>();
            previewEnemyCells = new List<EnemyCell>();
            towerGridsTowerCells.AddRange(enemyGrid.CreateGrid());
            previewEnemyCells.AddRange(enemyPreviewGrid.CreateGrid());
        }

        public List<EnemyBase> InstantiateWave(List<EnemyBase> listOfEnemies,int wavesSpawned)
        {
            List<EnemyBase> createdEnemies = new List<EnemyBase>();
            for (int i = 0; i < listOfEnemies.Count; i++) 
            {
                EnemyBase enemy = Instantiate(listOfEnemies[i], transform);
                enemy.transform.position = previewEnemyCells[i].transform.position;
                enemy.columnId = i; // set enemy column by default
                for (int j = 1; j < wavesSpawned/initSize; j++)
                {
                    _enemyBuffWave.listOfBuffs[i].CastBuff(ref enemy);   
                }
                enemy.ChangeLevel(enemy.level);
                createdEnemies.Add(enemy);
            }

            return createdEnemies;
        }
    }
}