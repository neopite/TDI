using System;
using UnityEngine;

namespace DefaultNamespace.Enemy
{
    public  class EnemyBase : MonoBehaviour , IDamageable
    {
        public int Level;
        private int currentHp;
        public EnemyType type;
        [SerializeField]public Vector2 Direction;
        [SerializeField]private float speed;
        [SerializeField]private Vector3 _currentTargetTile;
        public bool _isMoving;
        private Transform _enemyPosition;
        public int ColumnId;

        public void Start()
        {
            currentHp = Level;
            _enemyPosition = gameObject.transform;
        }

        public void Update()
        {
            if (_isMoving)
            {
                _enemyPosition.position = new Vector2(_enemyPosition.position.x, _enemyPosition.position.y + (Direction.y * speed * Time.deltaTime));
                if (Vector3.Distance(_enemyPosition.position,_currentTargetTile) < 0.1)
                {
                    _isMoving = false;
                    if (GameEvents.Instance.ListOfEnemy.Contains(this))
                    {
                        GameEvents.Instance.DestroyEnemyByGettingTarget(gameObject);
                    }
                }
            }
        }
        
        public void ReceiveDamage(int damage)
        {
            currentHp -= damage;
            if (currentHp <= 0)
            {
                GameEvents.Instance.ListOfEnemy.Add(this);
                GameEvents.Instance.OnDestroyEnemyByGettingTarget += DestroyEnemy;
            }
        }

        private void DestroyEnemy(GameObject gameObject)
        {
            Destroy(gameObject);
        }
        
        public void ChangeStage(Vector3 nextTilePosition)
        {
            _currentTargetTile= nextTilePosition;
            _isMoving = true;
        }
    }
}