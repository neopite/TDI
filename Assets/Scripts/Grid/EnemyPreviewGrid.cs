
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyPreviewGrid : Grid
    {
        [SerializeField] private float _offsetBetweenGrids;
        public override void SetPivotForGrid()
        {
            int dY = EnemyGridManager.Instance._enemyGrid.Rows - Rows;
            Vector2 enemyGrid = EnemyGridManager.Instance._enemyGrid.pivot;
            pivot = new Vector2(enemyGrid.x, enemyGrid.y + dY*TilesOffset);
        }
    }
}