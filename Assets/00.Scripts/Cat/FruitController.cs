using UnityEngine;

public class FruitController : MonoBehaviour
{
    [SerializeField] GameController game_controller;
    [SerializeField] Animator animator;
    [SerializeField] int point_value = 1;

    private void Start()
    {
        
    }

    public void TakeFruit()
    {
        game_controller.AddScore(point_value);
        animator.SetTrigger("on_pickup");
    }

    public void DestroyFruit()
    {
        Destroy(gameObject);
    }
}
