using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TowerGrid : Grid
    {
        [SerializeField]private TowerGridLocationType _towerGridType;
        [SerializeField] private float _offsetBetweenGrids;
        public override void SetPivotForGrid()
        {
            Vector2 enemyGridPivot = EnemyGridManager.Instance._enemyGrid.pivot;
            int enemyGridWidth = EnemyGridManager.Instance._enemyGrid.Columns;
            int enemyGridHeight = EnemyGridManager.Instance._enemyGrid.Rows;
            int dY = enemyGridHeight - Rows;
            if (_towerGridType == TowerGridLocationType.Left)
            {
                pivot = new Vector2(enemyGridPivot.x - Columns - _offsetBetweenGrids, enemyGridPivot.y + dY * TilesOffset);
            }
            else
            {
                pivot = new Vector2(enemyGridPivot.x + 0.5f +enemyGridWidth + _offsetBetweenGrids, enemyGridPivot.y + dY * TilesOffset);
            }
        }

        private enum TowerGridLocationType
        {
            Right,Left
        }
    }
}