using UnityEngine;

namespace DefaultNamespace.Enemy
{
    public  class EnemyBase : MonoBehaviour , IDamageable
    {
        public int level;
        private int _currentHp;
        public EnemyType type;
        public int columnId;
        public bool isMoving;
        private Transform _transform;
        
        [SerializeField]public Vector2 direction;
        [SerializeField]private float _speed;
        [SerializeField]private Vector3 _currentTargetTile;

        public void Start()
        {
            _currentHp = level;
            _transform = gameObject.transform;
        }

        public void Update()
        {
            if (isMoving)
            {
                var position = _transform.position;
                position = new Vector2(position.x, position.y + (direction.y * _speed * Time.deltaTime));
                _transform.position = position;
                if (Vector3.Distance(_transform.position,_currentTargetTile) < 0.15)
                {
                    isMoving = false;
                    if (GameEvents.Instance.listOfEnemy.Contains(this))
                    {
                        GameEvents.Instance.DestroyEnemyByGettingTarget(gameObject);
                    }
                }
            }
        }
        
        public void ReceiveDamage(int damage)
        {
            _currentHp -= damage;
            if (_currentHp <= 0)
            {
                GameEvents.Instance.listOfEnemy.Add(this);
                GameEvents.Instance.OnDestroyEnemyByGettingTarget += DestroyEnemy;
            }
        }

        private void DestroyEnemy(GameObject enemyObj)
        {
            Destroy(enemyObj);
        }
        
        public void ChangeStage(Vector3 nextTilePosition)
        {
            _currentTargetTile= nextTilePosition;
            isMoving = true;
        }
    }
}