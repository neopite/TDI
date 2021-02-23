using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreEvents :  MonoBehaviour
    {
        public static ScoreEvents Instance;
        public Action<int> OnChangeScore;

        public void ChangeScore(int score)
        {
            OnChangeScore?.Invoke(score);
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