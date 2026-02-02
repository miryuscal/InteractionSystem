using System;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Player
{
    public sealed class PlayerInventory : MonoBehaviour
    {
        public event Action<bool> KeyChanged;

        [SerializeField] private bool _hasKey;

        public bool HasKey => _hasKey;

        public void AddKey()
        {
            if (_hasKey)
                return;

            _hasKey = true;
            KeyChanged?.Invoke(_hasKey);
        }

        public bool ConsumeKey()
        {
            if (!_hasKey)
                return false;

            _hasKey = false;
            KeyChanged?.Invoke(_hasKey);
            return true;
        }
    }
}
