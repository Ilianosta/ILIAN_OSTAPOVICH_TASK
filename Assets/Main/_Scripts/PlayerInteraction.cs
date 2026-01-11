using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] float interactDistance = 4f;

    IInteractable currentInteractable;

    private void Update()
    {
        if (currentInteractable != null && InputManager.Instance.inputActions.Game.Interact.triggered)
        {
            Interact();
        }

        IInteractable newInteractable = GetInteractable();

        if (newInteractable == null)
        {
            if (currentInteractable != null)
            {
                currentInteractable.Outline(false);
                currentInteractable = null;
            }
            return;
        }

        if (currentInteractable != null && currentInteractable != newInteractable)
        {
            currentInteractable.Outline(false);
        }

        currentInteractable = newInteractable;
    }

    IInteractable GetInteractable()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactDistance, interactableLayer))
        {
            if (hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Outline(true);
                return interactable;
            }
        }
        return null;
    }

    void Interact()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
}
