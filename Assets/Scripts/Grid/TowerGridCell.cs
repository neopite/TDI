using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TowerGridCell : CellBase
{
    private GameObject _towerSelectionBar;
    public TowerBase tower;
    
    private void OnMouseDown()
    {
        TowerManager.Instance.LastPressedCell = this;
            _towerSelectionBar = GameObject.Find("Canvas").transform.Find("Towers_building_bar").gameObject;
            _towerSelectionBar.SetActive(true);
    }
}
