using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridManager : MonoBehaviour
{
    [SerializeField] private GameObject _tileSprite;

    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField]private float _verticalGridOffset;
    private int _horizontal;
    private float _vertical;
    public Vector2 pivot;
    public Vector2 Pivot { get; private set; }

    public float TilesOffset = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        _vertical = (int) Camera.main.orthographicSize;
        _horizontal = Mathf.RoundToInt(_vertical * Screen.width / Screen.height);
        pivot = new Vector2((float) (-columns/2.0 / TilesOffset), _vertical - rows - _verticalGridOffset);
        gameObject.transform.position = pivot;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                GameObject tile = Instantiate(_tileSprite, transform);
                SpawnTile(column,row,tile);
            }
        }
    }
    
    private void SpawnTile(int x, int y , GameObject tile)
    {
        tile.transform.position = new Vector2(x*TilesOffset+transform.position.x,
            y * TilesOffset + transform.position.y);
    }
}
