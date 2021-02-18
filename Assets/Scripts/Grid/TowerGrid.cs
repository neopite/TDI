using System;
using System.Collections.Generic;
using DefaultNamespace.Enemy;

namespace DefaultNamespace
{
    public class TowerGrid : Grid<TowerGridCell>
    {
        public Dictionary<int,TowerBase[]> GridTowers;

        private void Start()
        {
            GridTowers = new Dictionary<int, TowerBase[]>();
        }
    }
}