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
		interactText = "Press 'E' to Exit";
		Cursor.visible = true;
		isOpen = true;
		InventoryList.GetComponent<InventoryManager>().ListItems();
		Cursor.lockState = CursorLockMode.None;
		Time.timeScale = 0.0f;
	}

	public void HidePanel()
	{
		Inventory.SetActive(false);
		InventoryManager.Instance.CleanItems();
		craftingPanel.SetActive(false);
		interactText = "Press 'E' to Craft";
		Cursor.visible = false;
		isOpen = false;
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1.0f;
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
