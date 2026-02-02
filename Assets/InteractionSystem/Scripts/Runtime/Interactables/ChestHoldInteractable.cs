using InteractionSystem.Scripts.Runtime.Core;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Interactables
{
    public sealed class ChestHoldInteractable : MonoBehaviour, IInteractable, IHoldInteractable
    {
        [Header("Hold")]
        [SerializeField] private float _holdDurationSeconds = 1.25f;

        [Header("Animation")]
        [SerializeField] private Transform _lidPivot;
        [SerializeField] private float _openAngleX = -80f;
        [SerializeField] private float _openSpeed = 8f;

        private bool _isOpen;
        private Quaternion _closedRot;
        private Quaternion _openRot;

        public float HoldDurationSeconds => _holdDurationSeconds;

        private void Awake()
        {
            if (_lidPivot == null)
            {
                _lidPivot = transform;
            }

            _closedRot = _lidPivot.localRotation;
            _openRot = _closedRot * Quaternion.Euler(_openAngleX, 0f, 0f);
        }

        private void Update()
        {
            if (!_isOpen)
                return;

            _lidPivot.localRotation =
                Quaternion.Slerp(_lidPivot.localRotation, _openRot, Time.deltaTime * _openSpeed);
        }

        public string GetHoldActionText()
        {
            return "open chest";
        }

        public void Interact(GameObject interactor)
        {
            if (_isOpen)
                return;

            _isOpen = true;
        }
    }
}
