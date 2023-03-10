using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
	public Slot[] craftingSlots;
	[SerializeField] private ResultSlot outputSlot;
	public Item craftedItem;
	[SerializeField]private List<Recipe> recipeList;

	public AudioSource clearAudio;
	public AudioSource craftAudio;
	

	public bool IsEmpty(int i)
	{
		return craftingSlots[i] == null;
	}

	public Item GetItem(int i)
	{
		return craftingSlots[i].slottedItem;
	}
	private Item GetRecipeOutput()
	{
		foreach (Recipe recipe in recipeList)
		{
			bool completeRecipe = true;
			for (int i = 0; i < craftingSlots.Length; i++)
			{
				if (recipe.GetItem(i) != null)
				{
					if (IsEmpty(i) || GetItem(i) != recipe.GetItem(i))
					{
						// Empty position or different itemType
						completeRecipe = false;
					}
				}
			}
			if (completeRecipe)
			{
				return recipe.resultItem;
			}
		}
		return null;
	}



	private void CreateOutput()
	{
		Item recipeOutput = GetRecipeOutput();
		if (recipeOutput == null)
		{
			craftedItem = null;
		}
		else
		{
			craftedItem = recipeOutput;
		}
		
	}

	private Item GetCraftedItem()
	{
		CreateOutput();
		return craftedItem;
	}
	public void AddCreatedItem()
	{
		if (GetCraftedItem() != null)
		{
			craftAudio.Play();
			InventoryManager.Instance.Add(GetCraftedItem());
			Debug.Log("Item added to Inventory");
			Debug.Log(GetCraftedItem());
			for (int i = 0; i < craftingSlots.Length; i++)
			{
				craftingSlots[i].slottedItem = null;
			}
			outputSlot.craftedItem = null;
		}

	}

	public void ClearCraftingTable()
	{
		for (int i = 0; i < craftingSlots.Length; i++)
		{
			if (craftingSlots[i].slottedItem != null)
			{
				clearAudio.Play();
				InventoryManager.Instance.Add(craftingSlots[i].slottedItem);
				craftingSlots[i].slottedItem = null;
			}
			outputSlot.craftedItem = null;


		}
	}

	public void Update()
	{
		if (GetCraftedItem() != null)
		{
			Debug.Log(GetCraftedItem().itemName);
			outputSlot.AddItem(GetCraftedItem());

		}



		
	}



}
