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

        /*private void Start()
        {
            for (int i = 0; i < ListOfAvailableTowers.Count; i++)
            {
                GameObject gameObject = new GameObject();
                Image image = gameObject.AddComponent<Image>();
                image.sprite = ListOfAvailableTowers[i].GetComponent<SpriteRenderer>().sprite;
                RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(30, 30);
                Instantiate(gameObject, transform);
            }
        }*/
        private void Start()
        {
            for (int i = 0; i < ListOfAvailableTowers.Count; i++)
            {
                Button button = Instantiate(ItemPrefab, transform);
                button.image.sprite= ListOfAvailableTowers[i].GetComponent<SpriteRenderer>().sprite;
                int towerIndex = i; 
                button.onClick.AddListener( () => CreateTowerAtCell(towerIndex));
            }
        }

        private void CreateTowerAtCell(int towerIndex)
        {
            TowerGridManager.Instance.CreateTower(ListOfAvailableTowers[towerIndex]);
        }
    }
}