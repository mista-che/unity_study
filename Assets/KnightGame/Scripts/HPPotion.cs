using UnityEngine;


public class HPPotion : MonoBehaviour, IItemObject
{
    public ItemManager ItemInventory { get; set; }
    public GameObject ItemObject { get; set; }
    public string ItemName { get; set; }
    public Sprite ItemIcon { get; set; }

    public enum PotionType { Gold, HP, MP };
    public PotionType potion_type = PotionType.Gold;

    void Start()
    {
        ItemInventory = FindFirstObjectByType<ItemManager>();

        ItemObject = this.gameObject;
        ItemName = name;
        ItemIcon = GetComponent<SpriteRenderer>().sprite;
    }

    public void Obtain()
    {
        ItemObject.SetActive(false);

        ItemInventory.ObtainItem(this);
    }
    public void Use()
    {
        switch (potion_type)
        {
            case PotionType.Gold:
                break;
            case PotionType.HP:
                break;
            case PotionType.MP:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Obtain();
        }
    }
}


