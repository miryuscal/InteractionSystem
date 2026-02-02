using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Core
{
    public interface IInteractable
    {
        void Interact(GameObject interactor);
    }
}
