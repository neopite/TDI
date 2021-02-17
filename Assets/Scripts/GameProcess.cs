using System;
using System.Collections.Generic;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameProcess : MonoBehaviour
    {
        private List<Wave> _levelWaves;
        private EnemyGridManager _enemyGridManager;
        private TowerGridManager _towerGridManager;
        private int _wavesSpawned;
        private Dictionary<int, List<EnemyBase>> _wavesPosition;
        private List<EnemyCell> _tiles;
        private void Start()
        {
            _enemyGridManager = EnemyGridManager.Instance;
            _towerGridManager = TowerGridManager.Instance;
            _tiles = _enemyGridManager._towerGridsTowerCells;
            _levelWaves = _enemyGridManager.Waves;
            _wavesPosition = new Dictionary<int, List<EnemyBase>>();
            SpawnWave();
            MoveWave(0);
            MoveWave(1);
            SpawnWave();
            MoveWave(0);
            MoveWave(2);
        }

        private void Update()
        {
        }

        private void SpawnWave()
        {
            List<EnemyBase> listOfEnemies = new List<EnemyBase>();
            for (int i = 0; i < _levelWaves[_wavesSpawned].ListOfEnemies.Count; i++)
            {
                EnemyBase gm = Instantiate(_levelWaves[_wavesSpawned].ListOfEnemies[i],
                    transform.parent);
                gm.transform.position = EnemyGridManager.Instance._previewEnemyCells[i].transform.position;
                listOfEnemies.Add(gm);
            }
            _wavesPosition.Add(0,listOfEnemies);

            _wavesSpawned++;
        }

        private void MoveWave(int waveId)
        {
            for (int i = 0; i < _wavesPosition[waveId].Count; i++)
            {
                    _wavesPosition[waveId][i].ChangeStage(_tiles[waveId*_enemyGridManager._enemyGrid.Columns+i].transform.position);
            }
            List<EnemyBase> wave = _wavesPosition[waveId];
            _wavesPosition.Remove(waveId);
            _wavesPosition.Add(++waveId,wave);
        }

    }
}