using UnityEngine;


public interface IItemObject
{
    ItemManager ItemInventory { get; set; }
    GameObject ItemObject { get; set; }
    string ItemName { get; set; }
    Sprite ItemIcon { get; set; }

    void Obtain();
    void Use();
}
