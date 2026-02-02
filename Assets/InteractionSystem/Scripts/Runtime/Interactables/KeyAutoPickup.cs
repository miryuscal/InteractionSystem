using InteractionSystem.Scripts.Runtime.Core;
using InteractionSystem.Scripts.Runtime.Player;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Interactables
{
    public sealed class KeyAutoPickup : MonoBehaviour, IAutoCollectable
    {
        public void Collect(GameObject collector)
        {
            PlayerInventory inventory = collector.GetComponentInParent<PlayerInventory>();
            if (inventory == null)
            {
                Debug.LogWarning("PlayerInventory not found on collector.", this);
                return;
            }

            inventory.AddKey();

            // Key sahneden kaybolsun
            Destroy(gameObject);
        }
    }
}
