using InteractionSystem.Scripts.Runtime.Core;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Player
{
    public sealed class InteractionDetector : MonoBehaviour
    {
        public IInteractable Current { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            IInteractable interactable = other.GetComponentInParent<IInteractable>();
            if (interactable == null)
                return;

            Current = interactable;
        }

        private void OnTriggerExit(Collider other)
        {
            IInteractable interactable = other.GetComponentInParent<IInteractable>();
            if (interactable == null)
                return;

            if (Current == interactable)
                Current = null;
        }
    }
}
