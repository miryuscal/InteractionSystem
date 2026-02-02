using InteractionSystem.Scripts.Runtime.Core;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Interactables
{
    public sealed class DoorTestInteractable : MonoBehaviour, IInteractable
    {
        public void Interact(GameObject interactor)
        {
            Debug.Log($"Interacted with: {name} by: {interactor.name}");
        }
    }
}
