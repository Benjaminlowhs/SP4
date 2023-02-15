using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update(){
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractable interactable = GetInteractiveGameObject();
            if (interactable != null)
            {
                interactable.Interact(transform);
            }
        }
    }

    public IInteractable GetInteractiveGameObject()
    {
        List<IInteractable> interactableList = new List<IInteractable>();
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteractabe = null;
        foreach (IInteractable interactable in interactableList) {
            if (closestInteractabe == null){
                closestInteractabe = interactable;
            }else {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractabe.GetTransform().position)) {
                    // Closer
                    closestInteractabe = interactable;
                }
            }
        }
        return closestInteractabe;
    }
}
