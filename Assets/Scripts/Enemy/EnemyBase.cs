using System;
using UnityEngine;

namespace DefaultNamespace.Enemy
{
    public abstract class EnemyBase : MonoBehaviour , IDamageable
    {
        public int Level;
        private int currentHp;
        public EnemyType type;
        [SerializeField]public Vector2 Direction;
        [SerializeField]private float speed;
        [SerializeField]private Vector3 _currentTargetTile;
        public bool _isMoving;
        private Transform _enemyPosition;

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
                }
            }
        }
        
        public void ReceiveDamage(int damage)
        {
            currentHp -= damage;
            if (currentHp <= 0)
            {
                Destroy(gameObject);
            }
        }
        public void ChangeStage(Vector3 nextTilePosition)
        {
            _currentTargetTile= nextTilePosition;
            _isMoving = true;
        }
    }
}