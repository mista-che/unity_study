using UnityEngine;

namespace KnightGame
{
    public interface IDamageable
    {
        public abstract void TakeDamage(float damage);
        public abstract void Death();
    }
}
