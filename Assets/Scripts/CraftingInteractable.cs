using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingInteractable : MonoBehaviour, IInteractable
{	
	[SerializeField] private string interactText;
	[SerializeField] private PlayerInteract playerInteract;
	[SerializeField] private GameObject craftingContainer;
	[SerializeField] private GameObject Table;

	public void Interact(Transform interactorTransform)
	{
		Debug.Log("Interact");
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
