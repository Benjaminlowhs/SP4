using System.Linq;
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
	public Player player;


	private void Start()
	{
		slots = FindObjectsOfType<Slot>().OrderBy(slots => slots.index).ToArray();
		craftingInteractable = FindObjectOfType<CraftingInteractable>();
		player = FindObjectOfType<Player>();
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
				if (slots[i].slottedItem == null)
				{
					slots[i].AddItem(item);
					RemoveItem();
					break;
				}
			}
		}
		if (item.id == 9 && player.currentHealth != player.maxHealth)
		{
			player.Heal(player.maxHealth/2);
			RemoveItem();
		}
		if (item.id == 5 && player.currentHealth != player.maxHealth)
		{
			player.Heal(player.maxHealth/10);
			RemoveItem();
		}
	}
}
