using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
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
            TowerBase tower = Instantiate(towerBase, _lastPressedCell.transform);
            tower.transform.parent = _lastPressedCell.transform;
            _lastPressedCell.Tower = tower;
            _lastPressedCell = null;
        }
    }
}
