using InteractionSystem.Scripts.Runtime.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractionSystem.Scripts.Runtime.Player
{
    public sealed class PlayerInteractor : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InteractionDetector _detector;

        [Header("Input")]
        [SerializeField] private InputActionReference _interactAction;

        private void Awake()
        {
            if (_detector == null)
            {
                _detector = GetComponentInChildren<InteractionDetector>(true);
            }
        }

        private void OnEnable()
        {
            if (_interactAction != null)
            {
                _interactAction.action.Enable();
            }
        }

        private void OnDisable()
        {
            if (_interactAction != null)
            {
                _interactAction.action.Disable();
            }
        }

        private void Update()
        {
            if (_interactAction == null)
                return;

            if (!_interactAction.action.WasPressedThisFrame())
                return;

            IInteractable target = _detector != null ? _detector.Current : null;
            if (target == null)
                return;

            target.Interact(gameObject);
        }
    }
}
