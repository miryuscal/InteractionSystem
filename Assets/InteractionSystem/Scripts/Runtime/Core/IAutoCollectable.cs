using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Core
{
    public interface IAutoCollectable
    {
        void Collect(GameObject collector);
    }
}
