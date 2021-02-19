using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Enemy;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameProcess : MonoBehaviour
    {
        private List<Wave> _levelWaves;
        private EnemyManager _enemyManager;
        private TowerManager _towerManager;
        private int _wavesSpawned;
        private Dictionary<int, List<EnemyBase>> _wavesPosition;
        private List<EnemyCell> _tiles;
        public bool isLevelStarted;
        public TextMeshProUGUI GameState;
        private bool isSpawnEnd;

        private void Start()
        {
            _enemyManager = EnemyManager.Instance;
            _towerManager = TowerManager.Instance;
            _tiles = _enemyManager._towerGridsTowerCells;
            _levelWaves = _enemyManager.Waves;
            _wavesPosition = new Dictionary<int, List<EnemyBase>>();
            StartCoroutine(SpawnWave());
        }

        private void Update()
        {
            if (isLevelStarted && !isSpawnEnd)
            {
                List<int> wavesId = _wavesPosition.Keys.ToList();
                for (int i = 0 ;  i < wavesId.Count ; i++)
                {
                    MoveWave(wavesId[i]);
                }
                ShootWaves();
                StartCoroutine(SpawnWave());
                isLevelStarted = false;
            }
        }

        private IEnumerator SpawnWave()
        {
            isSpawnEnd = true;
            yield return new WaitForSeconds(.15f);
            if (_levelWaves.Count == _wavesSpawned)
            {
                Debug.Log("Waves Spanw ended");
            }
            else
            {
                List<EnemyBase> listOfEnemies = new List<EnemyBase>(); 
                for (int i = 0; i < _levelWaves[_wavesSpawned].ListOfEnemies.Count; i++) 
                { 

                    EnemyBase gm = Instantiate(_levelWaves[_wavesSpawned].ListOfEnemies[i],
                    transform.parent);
                    gm.ColumnId = i;
                gm.transform.position = EnemyManager.Instance._previewEnemyCells[i].transform.position;
                listOfEnemies.Add(gm);
                } 
                _wavesPosition.Add(0, listOfEnemies);

                 _wavesSpawned++;
                 
            }

            isSpawnEnd = false;
        }

        private void MoveWave(int waveId)
        {
            if (waveId == _enemyManager._enemyGrid.Rows)
            {
                Debug.Log("Game over");
                isLevelStarted = false;
            }
            else
                for (int i = 0; i < _wavesPosition[waveId].Count; i++)
                {
                    int enemyColumnId = _wavesPosition[waveId][i].ColumnId;
                    _wavesPosition[waveId][i]
                        .ChangeStage(_tiles[waveId * _enemyManager._enemyGrid.Columns + enemyColumnId].transform.position);
                }

            List<EnemyBase> wave = _wavesPosition[waveId];
            _wavesPosition.Remove(waveId);
            _wavesPosition[++waveId] = wave;
        }

        private void ShootWaves()
        {
            List<int> wavesRowsPos = _wavesPosition.Keys.ToList();
            for (int i = 0; i < wavesRowsPos.Count; i++)
            {
                if (_wavesPosition[wavesRowsPos[i]].Count != 0)
                {
                    ReceiveWaveDamage(wavesRowsPos[i]);
                }
                else
                {
                    _wavesPosition.Remove(wavesRowsPos[i]);
                }
            }
        }

        private void ReceiveWaveDamage(int wavePos)
        {

            TowerBase[,] leftTowers = _towerManager._leftTowerGrid.GridTowers;
            TowerBase[,] rightTowers = _towerManager._rightTowerGrid.GridTowers;
            List<EnemyBase> listOfEnemiesAtPos = _wavesPosition[wavePos];
            wavePos--;
            for (int i = 0; i < leftTowers.GetLength(1); i++)
            {
                if (leftTowers[wavePos, i] != null)
                {
                    if (i <= listOfEnemiesAtPos.Count)
                    {
                        if (leftTowers[wavePos, i].EnemyType == listOfEnemiesAtPos[0].type)
                        {
                            leftTowers[wavePos, i].Shoot(leftTowers[wavePos, i].Level, listOfEnemiesAtPos[0]);
                            listOfEnemiesAtPos.RemoveAt(0);

                        }
                    }
                }   
            }

            for (int i = 0; i < rightTowers.GetLength(1); i++)
            {
                if (rightTowers[wavePos, i] != null)
                {
                    if (i < listOfEnemiesAtPos.Count)
                    {
                        if (rightTowers[wavePos, i].EnemyType == listOfEnemiesAtPos[listOfEnemiesAtPos.Count-1].type)
                        {
                            rightTowers[wavePos, i].Shoot(rightTowers[wavePos, i].Level, listOfEnemiesAtPos[listOfEnemiesAtPos.Count-1]);
                            listOfEnemiesAtPos.RemoveAt(listOfEnemiesAtPos.Count-1);
                        }
                    }
                } 
            }
        }

        private void DestroyEnemy(EnemyBase enemyBase)
        {
            Destroy(enemyBase);
        }

         public void ChangeLevelState()
        {
            isLevelStarted = !isLevelStarted;
            GameState.text = isLevelStarted ? "Pause" : "Continue";
        }

        private IEnumerator Delay(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }
}