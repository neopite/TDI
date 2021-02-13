using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGridCell : MonoBehaviour
{
    private GameObject _towerSelectionBar;
    
    private void OnMouseDown()
    {
        TowerGridManager.Instance.LastPressedCell = this;
            _towerSelectionBar = GameObject.Find("Canvas").transform.Find("Towers_building_bar").gameObject;
            _towerSelectionBar.SetActive(true);
    }
}
