using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MoneyEvents : MonoBehaviour
    {
        public static MoneyEvents Instance;
        public Action<float> OnChangePlayerMoney;

        public void ChangePlayerMoney(float moneyCount)
        {
            OnChangePlayerMoney?.Invoke(moneyCount);
        }
        public void Start()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else Instance = this;
        }
    }
}