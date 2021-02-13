using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TowerGridManager : MonoBehaviour
{
    public Grid _leftTowerGrid;
    public Grid _rightTowerGrid;
   [SerializeField] private TowerGridCell _lastPressedCell;

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
        }else Destroy(gameObject);
        _leftTowerGrid.CreateGrid();
        _rightTowerGrid.CreateGrid();
    }

    public void CreateTower(TowerBase towerBase)
    {
        if (_lastPressedCell != null)
        {
            TowerBase tower = Instantiate(towerBase, _lastPressedCell.transform);
            tower.transform.parent = _lastPressedCell.transform;
            _lastPressedCell = null;
        }
    }
}
