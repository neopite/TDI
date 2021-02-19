using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Enemy;
using UnityEngine;

public class TowerManager : MonoBehaviour
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

    public static TowerManager Instance;
    
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
            TowerBase tower = Instantiate(towerBase, _lastPressedCell.transform);
            if (cellIndex < _towerCellsList.Count / 2)
            {
                int row = cellIndex / _leftTowerGrid.Columns;
                int col = cellIndex % _leftTowerGrid.Columns;
                int newCol = (row + 1) * _leftTowerGrid.Columns - cellIndex;
                _leftTowerGrid.GridTowers[cellIndex / _leftTowerGrid.Columns,newCol-1] = tower;
            }
            else
            {
                _rightTowerGrid.GridTowers[cellIndex / _rightTowerGrid.Columns - _rightTowerGrid.Rows,cellIndex % _rightTowerGrid.Columns] = tower;
            } 
            tower.transform.parent = _lastPressedCell.transform;
            _lastPressedCell.Tower = tower;
            _lastPressedCell = null;
        }
    }
    
    
    
}
