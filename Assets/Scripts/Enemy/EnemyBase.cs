using UnityEngine;

namespace DefaultNamespace.Enemy
{
    public  class EnemyBase : MonoBehaviour , IDamageable
    {
        [SerializeField]private int level;
        [SerializeField]private Vector2 direction;
        [SerializeField]private float _speed;
        [SerializeField]private Vector3 _currentTargetTile;
        [SerializeField] private EnemyKillReward _enemyKillReward;
        private Transform _transform;
        private EnemyView _enemyView;
        private int _currentHp;
        private bool _isMoving;
        public int ColumnId { get; set; }
        public int Level { get => level;set => level = value;}
        public EnemyType type;
        public bool IsAlive => _currentHp > 0;
        

        public void Start()
        {
            _currentHp = level;
            _transform = gameObject.transform;
            _enemyView = GetComponent<EnemyView>();
            _enemyView.enemyLevel.text = _currentHp.ToString();
            _enemyKillReward = GetComponent<EnemyKillReward>();
            EnemyHpEvents.Instance.OnChangeCurrentHp += ChangeCurrentHp;
        }

        public void Update()
        {
            if (_isMoving)
            {
                var position = _transform.position;
                position = new Vector2(position.x, position.y + (direction.y * _speed * Time.deltaTime));
                _transform.position = position;
                if (Vector3.Distance(_transform.position,_currentTargetTile) < 0.1f)
                {
                    _isMoving = false;
                    if (EnemyEvents.Instance.listOfEnemy.Contains(this))
                    {
                        EnemyEvents.Instance.DestroyEnemyByGettingTarget(gameObject);
                    }
                }
            }
        }

        public void ChangeLevel(int level)
        {
            this.level = level;
            _currentHp = level;
        }
        public void ReceiveDamage(int damage)
        {
            _currentHp -= damage;
            if (_currentHp <= 0)
            {
                EnemyEvents.Instance.listOfEnemy.Add(this);
                EnemyEvents.Instance.OnDestroyEnemyByGettingTarget += DestroyEnemy;
                MoneyEvents.Instance.ChangePlayerMoney(_enemyKillReward.MoneyReward);
                ScoreEvents.Instance.ChangeScore(_enemyKillReward.ScoreReward);
            }
        }

        private void DestroyEnemy(GameObject enemyObj)
        {
            Destroy(enemyObj);
        }
        
        public void ChangeStage(Vector3 nextTilePosition)
        {
            _currentTargetTile= nextTilePosition;
            _isMoving = true;
        }
        
        private void ChangeCurrentHp(EnemyBase enemy)
        {
            enemy._enemyView.enemyLevel.text= enemy._currentHp.ToString();
        }
    }
}