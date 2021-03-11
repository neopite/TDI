using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField]private TowerGrid leftTowerGrid;
    [SerializeField]private TowerGrid rightTowerGrid;

    public TowerGrid LeftTowerGrid => leftTowerGrid;
    public TowerGrid RightTowerGrid => rightTowerGrid;

    private TowerGridCell _lastPressedCell;
    private List<TowerGridCell> _towerCellsList;

    public TowerGridCell LastPressedCell
    {
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
        _towerCellsList.AddRange(leftTowerGrid.CreateGrid());
        _towerCellsList.AddRange(rightTowerGrid.CreateGrid());
    }

    public void CreateTower(TowerBase towerBase) 
    {
        if (_lastPressedCell != null && _lastPressedCell.tower==null)
        {
            int cellIndex = _towerCellsList.IndexOf(_lastPressedCell);
            TowerBase tower = Instantiate(towerBase, _lastPressedCell.transform);
            if (cellIndex < leftTowerGrid.Columns*leftTowerGrid.Rows)
            {
                int row = cellIndex / leftTowerGrid.Columns;
                int newCol = (row + 1) * leftTowerGrid.Columns - cellIndex;
                leftTowerGrid.GridTowers[cellIndex / leftTowerGrid.Columns,newCol-1] = tower;
            }
            else
            {
                rightTowerGrid.GridTowers[cellIndex / rightTowerGrid.Columns - rightTowerGrid.Rows,cellIndex % rightTowerGrid.Columns] = tower;
            } 
            tower.transform.parent = _lastPressedCell.transform;
            _lastPressedCell.tower = tower;
            _lastPressedCell = null;
            MoneyEvents.Instance.ChangePlayerMoney(-tower.Cost);
        }
    }
}
