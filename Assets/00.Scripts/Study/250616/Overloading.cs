using UnityEngine;

public class Overloading : MonoBehaviour
{

    private void Start()
    {
        Attack();
        Attack(true);
        Attack(10f);

        GameObject monster_ = new GameObject("Monster");
        Attack(10, monster_);
    }

    public void Attack()
    {

    }

    public void Attack(bool is_magic)
    {
        if (is_magic)
            Debug.Log("Magic Attack");
        else
            Debug.Log("Normal Attack");
    }

    public void Attack(float damage)
    {
        Debug.Log($"Attack dealt {damage} damage.");
    }

    public void Attack(float damage, GameObject target)
    {
        Debug.Log($"Attack dealt {damage} to {target.name}.");
    }
}
