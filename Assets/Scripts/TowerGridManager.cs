using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Enemy;
using UnityEngine;

public class TowerGridManager : MonoBehaviour
{
    public TowerGrid _leftTowerGrid;
    public TowerGrid _rightTowerGrid;
   [SerializeField] private TowerGridCell _lastPressedCell;
   public List<TowerGridCell> _towerCellsList;

    public TowerGridCell LastPressedCell
    {
        get => _lastPressedCell;
        set => _lastPressedCell = value;
    }

    public static TowerGridManager Instance;
    
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            _towerCellsList = new List<TowerGridCell>();
        }else Destroy(gameObject);
        _towerCellsList.AddRange(_leftTowerGrid.CreateGrid());
        _towerCellsList.AddRange(_rightTowerGrid.CreateGrid());
    }

    public void CreateTower(TowerBase towerBase) 
    {
        if (_lastPressedCell != null && _lastPressedCell.Tower==null)
        {
            int cellIndex = _towerCellsList.IndexOf(_lastPressedCell);
            TowerBase[] listOfTowers;
            TowerBase tower = Instantiate(towerBase, _lastPressedCell.transform);
            if (cellIndex < _towerCellsList.Count / 2)
            {
                if (_leftTowerGrid.GridTowers.TryGetValue(cellIndex / _leftTowerGrid.Columns, out listOfTowers))
                {
                    listOfTowers[cellIndex % _leftTowerGrid.Columns] = tower;
                    _leftTowerGrid.GridTowers[cellIndex / _leftTowerGrid.Columns] = listOfTowers;
                }
                else
                {
                    listOfTowers = new TowerBase[_leftTowerGrid.Columns];
                    listOfTowers[cellIndex % _leftTowerGrid.Columns] = tower;
                    _leftTowerGrid.GridTowers.Add(cellIndex / _leftTowerGrid.Columns, listOfTowers);

                }
            }
            else
            {
                if (_rightTowerGrid.GridTowers.TryGetValue(cellIndex / _rightTowerGrid.Columns, out listOfTowers))
                {
                    listOfTowers[cellIndex % _rightTowerGrid.Columns] = tower;
                    _rightTowerGrid.GridTowers[cellIndex / _rightTowerGrid.Columns - _rightTowerGrid.Rows] = listOfTowers;
                }
                else
                {
                    listOfTowers = new TowerBase[_rightTowerGrid.Columns];
                    listOfTowers[cellIndex % _rightTowerGrid.Columns] = tower;
                    _rightTowerGrid.GridTowers.Add(cellIndex / _rightTowerGrid.Columns - _rightTowerGrid.Rows, listOfTowers);
                }
            }

            tower.transform.parent = _lastPressedCell.transform;
            _lastPressedCell.Tower = tower;
            _lastPressedCell = null;
        }
    }
}
