using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private GameObject _tileSprite;


    [Range(1,9)][SerializeField] private int rows;
    [Range(1,9)][SerializeField] private int columns;
    [Range(0,3)][SerializeField]private float _verticalGridOffset;
    [Range(1,2)]public float TilesOffset = 1.1f;
    [Range(-2,2)]public float OffsetBetweenGrids;
    public int Rows
    {
        get => rows;
        set => rows = value;
    }

    public int Columns
    {
        get => columns;
        private set => columns = value;
    }
    
    private int _horizontal;
    private float _vertical;
    public Vector2 pivot;
    public GridPosition GridPos;


    public List<TowerGridCell> CreateGrid()
    {
        List<TowerGridCell> _gridCells = new List<TowerGridCell>();
        SetPivotForGrid();
        for (int row = rows; 0 < row ; row--)
        {
            for (int column = 0; column < columns; column++)
            {
                GameObject tile = Instantiate(_tileSprite, transform);
                TowerGridCell tileComponent = tile.GetComponent<TowerGridCell>();
                _gridCells.Add(tileComponent);
                var transformPosition = tile.transform.position;
                transformPosition.z = -10;
                tile.transform.position = transformPosition;
                SpawnTile(column,row,tile);
            }
        }

        return _gridCells;
    }

    public virtual void SetPivotForGrid()
    {
        Grid enemyGrid = EnemyGridManager.Instance._enemyGrid;
        Vector2 enemyGridPivot = enemyGrid.pivot;
        if (GridPos == GridPosition.Center)
        {
            _vertical = (int) Camera.main.orthographicSize;
            _horizontal = Mathf.RoundToInt(_vertical * Screen.width / Screen.height);
            pivot = new Vector2((float) (-columns / 2.0 / TilesOffset), _vertical - (rows/2)-_verticalGridOffset);
        }
        else if(GridPos == GridPosition.Left)
        {
            pivot = new Vector2(enemyGridPivot.x - Columns + OffsetBetweenGrids, enemyGridPivot.y);
        }else if (GridPos == GridPosition.Right)
        {
            pivot = new Vector2(enemyGridPivot.x + enemyGrid.columns + OffsetBetweenGrids, enemyGridPivot.y);
        }else if (GridPos == GridPosition.Top)
        {
            pivot = new Vector2(enemyGridPivot.x, -(enemyGridPivot.y + OffsetBetweenGrids));
        }else if (GridPos == GridPosition.Bottom)
        {
            pivot = new Vector2(enemyGridPivot.x, enemyGridPivot.y + enemyGrid.rows - OffsetBetweenGrids);
        }
    }
    
    public virtual void SpawnTile(int x, int y , GameObject tile)
    {
        tile.transform.position = new Vector2(x*TilesOffset+pivot.x,
            y * TilesOffset- pivot.y );
    }

    public enum GridPosition
    {
        Left,Right,Top,Bottom,Center
    }
}
