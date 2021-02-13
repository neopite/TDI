using UnityEngine;

namespace DefaultNamespace
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }else Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
}