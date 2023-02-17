using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
	public static CraftingManager Instance;
	public Slot[] craftingSlots;
	[SerializeField] private ResultSlot outputSlot;

	[SerializeField]private List<Recipe> recipeList;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		GetRecipeOutput();
	}

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
		foreach (Recipe recipe in recipeList){		
			bool completeRecipe = true;
			for (int i = 0; i < craftingSlots.Length; i++){
				if (recipe.GetItem(craftingSlots,i) != null){
					if (IsEmpty(i) || GetItem(i) != recipe.GetItem(craftingSlots,i)){
						// Empty position or different itemType
						completeRecipe = false;
					}
				}
			}
			if (completeRecipe){
				return recipe.resultItem;
			}
			Debug.Log("Recipe Output" + recipe.resultItem);
		}

		return null;
	}

	public void AddCreatedItem()
	{
		if (GetRecipeOutput() != null)
		{
			InventoryManager.Instance.Add(GetRecipeOutput());
			Debug.Log("Item added to Inventory");
			Debug.Log(GetRecipeOutput());
		}

	}

}
