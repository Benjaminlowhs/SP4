using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingInteractUI : MonoBehaviour
{
	[SerializeField] private GameObject craftingContainer;
	[SerializeField] private PlayerInteract playerInteract;


	// Start is called before the first frame update
	private void Update()
	{
		if (playerInteract.GetInteractiveGameObject() != null )
		{
			ShowCraftingMenu();
		}
		else
		{
			HideCraftingMenu();
		}
	}
	public void ShowCraftingMenu()
	{
		craftingContainer.SetActive(true);
	}
	public void HideCraftingMenu()
	{
		craftingContainer.SetActive(false);
	}


}
