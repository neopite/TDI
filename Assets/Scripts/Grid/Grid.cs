using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Grid<T> : MonoBehaviour where T : CellBase
{
    [SerializeField] private GameObject tileSprite;
    [Range(1,9)][SerializeField] private int _rows;
    [Range(1,9)][SerializeField] private int _columns;
    [Range(0,3)][SerializeField]private float verticalGridOffset;
    [Range(1,2)]public float tilesOffset = 1.1f;
    [Range(-2,2)]public float offsetBetweenGrids;
    public GridPosition gridPos;
    private Vector2 _pivot;
    
    public int Rows
    { 
        get => _rows;
        set => _rows = value;
    }

    public int Columns
    {
        get => _columns;
        private set => _columns = value;
    }
    
    public List<T> CreateGrid()
    {
        List<T> gridCells = new List<T>();
        SetPivotForGrid();
        for (int row = _rows; 0 < row ; row--)
        {
            for (int column = 0; column < _columns; column++)
            {
                GameObject tile = Instantiate(tileSprite, transform);
                T tileComponent = tile.GetComponent<T>();
                gridCells.Add(tileComponent);
                var transformPosition = tile.transform.position;
                transformPosition.z = -10;
                tile.transform.position = transformPosition;
                SpawnTile(column,row,tile);
            }
        }

        return gridCells;
    }

    private void SetPivotForGrid()
    {
        Grid<EnemyCell> enemyGrid = EnemyManager.Instance.enemyGrid;
        Vector2 enemyGridPivot = enemyGrid._pivot;
        if (gridPos == GridPosition.Center)
        {
            float vertical= (int) Camera.main.orthographicSize;
            _pivot = new Vector2((float) (-_columns / 2.0 / tilesOffset), vertical - (_rows/2)-verticalGridOffset);
        }
        else if(gridPos == GridPosition.Left)
        {
            _pivot = new Vector2(enemyGridPivot.x - Columns + offsetBetweenGrids, enemyGridPivot.y);
        }else if (gridPos == GridPosition.Right)
        {
            _pivot = new Vector2(enemyGridPivot.x + enemyGrid._columns + offsetBetweenGrids, enemyGridPivot.y);
        }else if (gridPos == GridPosition.Top)
        {
            _pivot = new Vector2(enemyGridPivot.x, -(enemyGridPivot.y + offsetBetweenGrids));
        }else if (gridPos == GridPosition.Bottom)
        {
            _pivot = new Vector2(enemyGridPivot.x, enemyGridPivot.y + enemyGrid._rows - offsetBetweenGrids);
        }
    }
    
    private void SpawnTile(int x, int y , GameObject tile)
    {
        tile.transform.position = new Vector2(x*tilesOffset+_pivot.x,
            y * tilesOffset- _pivot.y );
    }

    public enum GridPosition
    {
        Left,Right,Top,Bottom,Center
    }
}
