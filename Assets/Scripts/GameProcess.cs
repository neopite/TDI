using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

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
        private bool _isLevelStarted;
        private bool _isSpawnEnd;
        public int wavesDestroyed;
        [SerializeField]private TextMeshProUGUI gameState;
        [SerializeField]private Image gameOver;


        private void Start()
        {
            _enemyManager = EnemyManager.Instance;
            _towerManager = TowerManager.Instance;
            _tiles = _enemyManager.towerGridsTowerCells;
            _levelWaves = _enemyManager.waves;
            _wavesPosition = new Dictionary<int, List<EnemyBase>>();
            StartCoroutine(SpawnWave());
        }

        private void Update()
        {
            if (_isLevelStarted && !_isSpawnEnd)
            {
                List<int> wavesId = _wavesPosition.Keys.OrderByDescending(x=>x).ToList();
                foreach (var waveNumber in wavesId)
                {
                    MoveWave(waveNumber);
                }
                
                ShootWaves();
                StartCoroutine(SpawnWave());
                _isLevelStarted = false;
            }
        }

        private IEnumerator SpawnWave()
        {
            _isSpawnEnd = true;
            yield return new WaitForSeconds(.15f);
            if (_levelWaves.Count != _wavesSpawned)
            {
                List<EnemyBase> listOfEnemies = new List<EnemyBase>(); 
                for (int i = 0; i < _levelWaves[_wavesSpawned].ListOfEnemies.Count; i++) 
                {
                    EnemyBase enemy = Instantiate(_levelWaves[_wavesSpawned].ListOfEnemies[i], transform);
                    enemy.transform.position = EnemyManager.Instance.previewEnemyCells[i].transform.position;
                    enemy.columnId = i; // set enemy column by default
                    listOfEnemies.Add(enemy);
                } 
                _wavesPosition.Add(0, listOfEnemies);
                _wavesSpawned++;            
            }
            _isSpawnEnd = false;
        }

        private void MoveWave(int waveId)
        {
            if (waveId >= _enemyManager.enemyGrid.Rows)
            {
                _isLevelStarted = false;
                CreateGameOverWindow();
            }
            else
                for (int i = 0; i < _wavesPosition[waveId].Count; i++)
                {
                    int enemyColumnId = _wavesPosition[waveId][i].columnId;
                    _wavesPosition[waveId][i]
                        .ChangeStage(_tiles[waveId * _enemyManager.enemyGrid.Columns + enemyColumnId].transform.position);
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
                ReceiveWaveDamage(wavesRowsPos[i]);
            }
        }

        private void ReceiveWaveDamage(int wavePos)
        {
            TowerBase[,] leftTowers = _towerManager.leftTowerGrid.GridTowers;
            TowerBase[,] rightTowers = _towerManager.rightTowerGrid.GridTowers;
            List<EnemyBase> listOfEnemiesAtPos = _wavesPosition[wavePos];
            DamageEnemiesPerStep(0,leftTowers,listOfEnemiesAtPos,wavePos-1);
            if (listOfEnemiesAtPos.Count != 0)
            {
                DamageEnemiesPerStep(listOfEnemiesAtPos.Count-1,rightTowers,listOfEnemiesAtPos,wavePos-1);     
            }else{
                _wavesPosition.Remove(wavePos);
                wavesDestroyed++;
                if (wavesDestroyed % _enemyManager.enemyGrid.Columns == 0)
                {
                    MoneyEvents.Instance.ChangePlayerMoney(_enemyManager.waveReward.moneyReward);
                    ScoreEvents.Instance.ChangeScore(_enemyManager.waveReward.scoreReward);
                }
            }
        }

        private void DamageEnemiesPerStep(int enemyId,TowerBase[,] towers, List<EnemyBase> listOfEnemies,int wavePos)
        {
            for (int i = 0; i < towers.GetLength(1); i++)
                if (towers[wavePos, i] != null)
                {
                    if (i <= listOfEnemies.Count)
                    {
                        if (towers[wavePos, i].enemyType == listOfEnemies[enemyId].type)
                        {
                            towers[wavePos, i].Shoot(towers[wavePos, i].level, listOfEnemies[enemyId]);
                            listOfEnemies.RemoveAt(enemyId);
                        }
                    }
                }
        }

        private void CreateGameOverWindow()
        {
            gameOver.gameObject.SetActive(true);
        }
        
        public void ChangeLevelState()
        {
            _isLevelStarted = !_isLevelStarted;
            gameState.text = "Continue";
        }
    }
}