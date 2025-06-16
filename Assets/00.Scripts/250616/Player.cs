using UnityEngine;

public class Player : Entity
{
    public override void Attack()
    {
        base.Attack();
        Debug.Log("Player.Attack");
    }

    public override void Move()
    {
        Debug.Log("Player.Move");
    }
}
