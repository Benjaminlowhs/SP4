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
		slots = FindObjectsOfType<Slot>();
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
				if (slots[3 - i].slottedItem == null)
				{
					slots[3 - i].AddItem(item);
					RemoveItem();
					break;
				}
			}
		}
		if (item.id == 9 && player.currentHealth != player.maxHealth)
		{
			player.currentHealth += 20;
			if (player.currentHealth > player.maxHealth)
			{
				player.currentHealth = player.maxHealth;
			}
			RemoveItem();
		} 
	}
}
