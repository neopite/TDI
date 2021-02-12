using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private GameObject _tileSprite;

    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField]private float _verticalGridOffset;
    public float TilesOffset = 1.1f;
    public int Rows
    {
        get => rows;
        set => rows = value;
    }

    public int Columns
    {
        get => columns;
        set => columns = value;
    }
    
    private int _horizontal;
    private float _vertical;
    public Vector2 pivot;

    public void CreateGrid()
    {
        SetPivotForGrid();
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                GameObject tile = Instantiate(_tileSprite, transform);
                SpawnTile(column,row,tile);
            }
        }
    }

    public virtual void SetPivotForGrid()
    {
        _vertical = (int) Camera.main.orthographicSize;
        _horizontal = Mathf.RoundToInt(_vertical * Screen.width / Screen.height);
        pivot = new Vector2((float) (-columns/2.0 / TilesOffset), _vertical - rows - _verticalGridOffset);
    }
    
    private void SpawnTile(int x, int y , GameObject tile)
    {
        tile.transform.position = new Vector2(x*TilesOffset+pivot.x,
            y * TilesOffset + pivot.y);
    }
}
