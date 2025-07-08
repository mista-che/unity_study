using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace KnightGame
{
    public class ItemSlot : MonoBehaviour
    {
        private IItemObject item;

        private Button self_slot_button;
        private Image self_icon;

        public bool is_empty = true;

        private void Awake()
        {
            self_slot_button = GetComponent<Button>();
            self_icon = transform.GetChild(0).GetComponent<Image>();
            
            self_slot_button.onClick.AddListener(UseItem);
        }

        private void OnEnable()
        {
            if (is_empty)
            {
                self_slot_button.interactable = false;
                self_icon.gameObject.SetActive(false);
            }
            else
            {
                self_slot_button.interactable = true;
                self_icon.gameObject.SetActive(true);
            }
        }

        public void AddItem(IItemObject new_item)
        {
            item = new_item;
            is_empty = false;

            self_icon.sprite = item.ItemIcon;
            self_icon.SetNativeSize();
        }

        public void UseItem()
        {
            if (item != null)
            {
                item.Use();
                ClearSlot();
            }

        }

        public void ClearSlot()
        {
            item = null;
            is_empty = true;
            self_slot_button.interactable = false;
            self_icon.gameObject.SetActive(false);
        }
    }
}
