using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable
{
    public float hp;
    public float move_speed;

    private void Update()
    {
        Move();
    }

    public void Damage(float damage)
    {
        hp -= damage;
    }

    public virtual void Attack()
    {
        Debug.Log("Entity Attack");
    }
    /*
    public virtual void Move()
    {
        Debug.Log("Entity Move");
    }
    */

    public abstract void Move();
}
