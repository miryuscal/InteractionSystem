using InteractionSystem.Scripts.Runtime.Player;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.UI
{
    public sealed class KeyIconUI : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _inventory;
        [SerializeField] private GameObject _iconRoot;

        private void Awake()
        {
            if (_iconRoot != null)
            {
                _iconRoot.SetActive(false);
            }
        }

        private void OnEnable()
        {
            if (_inventory != null)
            {
                _inventory.KeyChanged += OnKeyChanged;
                OnKeyChanged(_inventory.HasKey);
            }
        }

        private void OnDisable()
        {
            if (_inventory != null)
            {
                _inventory.KeyChanged -= OnKeyChanged;
            }
        }

        private void OnKeyChanged(bool hasKey)
        {
            if (_iconRoot != null)
            {
                _iconRoot.SetActive(hasKey);
            }
        }
    }
}
