using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGridManager : MonoBehaviour
{
    public Grid _leftTowerGrid;
    public Grid _rightTowerGrid;
    public static TowerGridManager Instance;
    
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }else Destroy(gameObject);
        _leftTowerGrid.CreateGrid();
        _rightTowerGrid.CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
