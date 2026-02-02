using InteractionSystem.Scripts.Runtime.Core;
using InteractionSystem.Scripts.Runtime.UI;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Interactables
{
    public sealed class LeverToggleInteractable : MonoBehaviour, IInteractable
    {
        [Header("Target")]
        [SerializeField] private Light _targetLight;
        [SerializeField] private GameObject _targetObject; // Light yerine objeyi aç/kapatmak istersen

        [Header("Lever Visual")]
        [SerializeField] private Transform _leverHandle;
        [SerializeField] private float _onAngleX = -35f;
        [SerializeField] private float _offAngleX = 35f;
        [SerializeField] private float _animSpeed = 12f;

        [Header("UI")]
        [SerializeField] private NotificationUI _notificationUI;
        [SerializeField] private bool _showNotification = true;

        private bool _isOn;
        private Quaternion _handleOffRot;
        private Quaternion _handleOnRot;

        private void Awake()
        {
            if (_leverHandle != null)
            {
                _handleOffRot = _leverHandle.localRotation;
                _handleOnRot = _handleOffRot * Quaternion.Euler(_onAngleX - _offAngleX, 0f, 0f);
            }

            ApplyState(_isOn, instant: true);
        }

        private void Update()
        {
            if (_leverHandle == null)
                return;

            Quaternion target = _isOn ? _handleOnRot : _handleOffRot;
            _leverHandle.localRotation = Quaternion.Slerp(_leverHandle.localRotation, target, Time.deltaTime * _animSpeed);
        }

        public void Interact(GameObject interactor)
        {
            _isOn = !_isOn;
            ApplyState(_isOn, instant: false);

            if (_showNotification && _notificationUI != null)
            {
                _notificationUI.Show(_isOn ? "Light turned ON." : "Light turned OFF.");
            }
        }

        private void ApplyState(bool isOn, bool instant)
        {
            if (_targetLight != null)
            {
                _targetLight.enabled = isOn;
            }

            if (_targetObject != null)
            {
                _targetObject.SetActive(isOn);
            }

            if (instant && _leverHandle != null)
            {
                _leverHandle.localRotation = isOn ? _handleOnRot : _handleOffRot;
            }
        }
    }
}
