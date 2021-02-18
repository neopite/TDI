using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        public bool isLevelStarted;
        public TextMeshProUGUI GameState;
        private bool isSpawnEnd;

        private void Start()
        {
            _enemyGridManager = EnemyGridManager.Instance;
            _towerGridManager = TowerGridManager.Instance;
            _tiles = _enemyGridManager._towerGridsTowerCells;
            _levelWaves = _enemyGridManager.Waves;
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
                gm.transform.position = EnemyGridManager.Instance._previewEnemyCells[i].transform.position;
                listOfEnemies.Add(gm);
                } 
                _wavesPosition.Add(0, listOfEnemies);

                 _wavesSpawned++;
                 
            }

            isSpawnEnd = false;
        }

        private void MoveWave(int waveId)
        {
            if (waveId == _enemyGridManager._enemyGrid.Rows)
            {
                Debug.Log("Game over");
                isLevelStarted = false;
            }
            else
                for (int i = 0; i < _wavesPosition[waveId].Count; i++)
                {
                    _wavesPosition[waveId][i]
                        .ChangeStage(_tiles[waveId * _enemyGridManager._enemyGrid.Columns + i].transform.position);
                }

            List<EnemyBase> wave = _wavesPosition[waveId];
            _wavesPosition.Remove(waveId);
            _wavesPosition[++waveId] = wave;
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