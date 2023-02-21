using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingInteractable : MonoBehaviour, IInteractable
{	
	[SerializeField] private string interactText;
	[SerializeField] private PlayerInteract playerInteract;
	[SerializeField] private GameObject craftingPanel;
	public GameObject Inventory;
	public GameObject InventoryList;

	private bool isOpen;

	private void Start()
	{
		isOpen = false;
	}
	public bool GetOpenStatus()
	{
		return isOpen;
	}
	public void ShowPanel()
	{
		Inventory.SetActive(true);
		craftingPanel.SetActive(true);
		Time.timeScale = 0.0f;
		interactText = "Press 'E' to Exit";
		Cursor.visible = true;
		isOpen = true;
		InventoryList.GetComponent<InventoryManager>().ListItems();
		Cursor.lockState = CursorLockMode.None;
	}

	public void HidePanel()
	{
		Inventory.SetActive(false);
		InventoryManager.Instance.CleanItems();
		craftingPanel.SetActive(false);
		Time.timeScale = 1.0f;
		interactText = "Press 'E' to Craft";
		Cursor.visible = false;
		isOpen = false;
		Cursor.lockState = CursorLockMode.Locked;

	}
	public void Interact(Transform interactorTransform)
	{
		if (!isOpen)
		{
			ShowPanel();
		}
		else
		{
			HidePanel();
		}
	}

	public string GetInteractText()
	{
		return interactText;
	}

	public Transform GetTransform()
	{
		return transform;
	}
}
