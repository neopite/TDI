using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TowerBarSelect : MonoBehaviour
    {
        public List<TowerBase> ListOfAvailableTowers;
        public Button ItemPrefab;
        
        private void Start()
        {
            for (int i = 0; i < ListOfAvailableTowers.Count; i++)
            {
                Button button = Instantiate(ItemPrefab, transform);
                button.image.sprite= ListOfAvailableTowers[i].GetComponent<SpriteRenderer>().sprite;
                int towerIndex = i; 
                button.onClick.AddListener( () => TryCreateTowerAtCell(towerIndex));
            }
        }

        private void TryCreateTowerAtCell(int towerIndex)
        {
            if (PlayerData.Instance.IsEnoughMoney(ListOfAvailableTowers[towerIndex].Cost))
            {
                TowerManager.Instance.CreateTower(ListOfAvailableTowers[towerIndex]);
            }else Debug.Log("No money");
        }
    }
}