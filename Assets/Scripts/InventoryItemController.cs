using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    public Button RemoveButton;
	public Slot[] slots;
    public CraftingInteractable craftingInteractable;
	private void Start()
	{
		slots = GameObject.FindObjectsOfType<Slot>();
        craftingInteractable = GameObject.FindObjectOfType<CraftingInteractable>();
	}
	public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newitem)
    {
        item = newitem;
    }

    public void AddToSlot()
    {
        if (craftingInteractable.GetOpenStatus() == true)
        {
            for (int i = 3; i >= 0; i--)
            {
                if (slots[i].slottedItem == null)
                {
                    slots[i].AddItem(item);
                    RemoveItem();
                    break;
                }
            }
        }
	}
}
