using KnightGame;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] all_items;

    [SerializeField] private Transform slot_group;
    public ItemSlot[] item_grid;

    private void Start()
    {
        item_grid = slot_group.GetComponentsInChildren<ItemSlot>(true); // setting arg to "true" grabs components, even if object is turned off
    }

    public void DropItem(Vector3 drop_location)
    {
        var random_item = Random.Range(0, all_items.Length);

        GameObject item = Instantiate(all_items[random_item], drop_location, Quaternion.identity);

        Rigidbody2D item_rigidbody = item.GetComponent<Rigidbody2D>();

        item_rigidbody.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        item_rigidbody.AddForceY(3f, ForceMode2D.Impulse);

        float random_power = Random.Range(-1.5f, 1.5f);
        item_rigidbody.AddTorque(random_power, ForceMode2D.Impulse);
    }

    public void ObtainItem(IItemObject item)
    {
        foreach (var item_slot in item_grid)
        {
            if (item_slot.is_empty)
            {
                item_slot.AddItem(item);
                break;
            }
        }
    }
}
