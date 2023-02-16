using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
	public Slot[] craftingSlots;
	private Slot outputSlot;

	private Item currentItem;
	public Image customCursor;

	private List<Recipe> recipeList;

	public CraftingManager(List<Recipe> recipeList)
	{
		this.recipeList = recipeList;
	}

	public bool IsEmpty(int i)
	{
		return craftingSlots[i] == null;
	}

	public Item GetItem(int i)
	{
		return craftingSlots[i].item;
	}
	private Item GetRecipeOutput()
	{			
		bool completeRecipe = true;
		foreach (Recipe recipe in recipeList)
		{
			for (int i = 0; i < craftingSlots.Length; i++)
			{
				if (recipe != null)
				{
					if (IsEmpty(i) || GetItem(i) != recipe.GetItem(craftingSlots,i))
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
		if (recipeOutput != null)
		{
			outputSlot.SetItem(recipeOutput);
		}
	}

	public void AddToInventory()
	{

	}

	public void OnMouseDownItem(Item item)
	{
		if (currentItem == null)
		{
			currentItem = item;
			customCursor.gameObject.SetActive(true);
			customCursor.sprite = currentItem.icon;
		}
	}
}
