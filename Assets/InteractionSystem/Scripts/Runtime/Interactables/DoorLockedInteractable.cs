using InteractionSystem.Scripts.Runtime.Core;
using InteractionSystem.Scripts.Runtime.Player;
using InteractionSystem.Scripts.Runtime.UI;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Interactables
{
    public sealed class DoorLockedInteractable : MonoBehaviour, IInteractable
    {
        [Header("Door")]
        [SerializeField] private Transform _doorPivot;
        [SerializeField] private float _openAngle = 90f;
        [SerializeField] private float _speed = 8f;

        [Header("UI")]
        [SerializeField] private NotificationUI _notificationUI;

        private bool _isOpen;
        private Quaternion _closedRot;
        private Quaternion _openRot;

        private void Awake()
        {
            if (_doorPivot == null)
            {
                _doorPivot = transform;
            }

            _closedRot = _doorPivot.localRotation;
            _openRot = _closedRot * Quaternion.Euler(0f, _openAngle, 0f);
        }

        private void Update()
        {
            Quaternion target = _isOpen ? _openRot : _closedRot;
            _doorPivot.localRotation = Quaternion.Slerp(_doorPivot.localRotation, target, Time.deltaTime * _speed);
        }

        public void Interact(GameObject interactor)
        {
            if (_isOpen)
                return;

            PlayerInventory inventory = interactor.GetComponentInParent<PlayerInventory>();
            if (inventory == null)
            {
                Debug.LogWarning("PlayerInventory not found on interactor.", this);
                return;
            }

            if (!inventory.HasKey)
            {
                if (_notificationUI != null)
                {
                    _notificationUI.Show("You need to pick up the key.");
                }
                return;
            }

            // Kapýyý aç + anahtarý tüket
            bool consumed = inventory.ConsumeKey();
            if (!consumed)
                return;

            _isOpen = true;
        }
    }
}
