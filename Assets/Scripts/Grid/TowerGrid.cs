using System;
using System.Collections.Generic;
using DefaultNamespace.Enemy;

namespace DefaultNamespace
{
    public class TowerGrid : Grid<TowerGridCell>
    {
        public TowerBase[,] GridTowers;

        private void Start()
        {
            GridTowers = new TowerBase[Rows,Columns];
        }
    }
}