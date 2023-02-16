using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingInteractable : MonoBehaviour, IInteractable
{	
	[SerializeField] private string interactText;
	[SerializeField] private PlayerInteract playerInteract;
	[SerializeField] private GameObject craftingPanel;
	private bool isOpen;

	private void Start()
	{
		isOpen = false;
	}

	public void ShowPanel()
	{
		craftingPanel.SetActive(true);
		interactText = "Press 'E' to Exit";
		Cursor.visible = true;
		isOpen = true;
	}

	public void HidePanel()
	{
		craftingPanel.SetActive(false);
		interactText = "Press 'E' to Craft";
		Cursor.visible = false;
		isOpen = false;
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
