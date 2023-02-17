using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    public Button RemoveButton;
  
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
		switch (Slot.Instance.index)
		{
			case 2:
				if (Slot.Instance.slottedItem == null)
				{
					Slot.Instance.AddItem(item);
					RemoveItem();

				}
				break;
			case 1:
				if (Slot.Instance.slottedItem == null)
				{
					Slot.Instance.AddItem(item);
					RemoveItem();

				}
				break;
			case 0:
				if (Slot.Instance.slottedItem == null)
				{
					Slot.Instance.AddItem(item);
					RemoveItem();

				}
				break;
			case 3:
				if (Slot.Instance.slottedItem == null)
				{
					Slot.Instance.AddItem(item);
					RemoveItem();

				}
				break;
		}
	}
}
