using DefaultNamespace.Enemy;

namespace DefaultNamespace
{
    public interface IShootable
    {
        void Shoot(int damage , EnemyBase target);
    }
}