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
		slots = FindObjectsOfType<Slot>();
		craftingInteractable = FindObjectOfType<CraftingInteractable>();
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

    public void UseItem()
    {
        if (craftingInteractable.GetOpenStatus() == true)
        {
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[3 - i].slottedItem == null)
				{
					slots[3 - i].AddItem(item);
					RemoveItem();
					break;
				}
			}
		}
	}
}
