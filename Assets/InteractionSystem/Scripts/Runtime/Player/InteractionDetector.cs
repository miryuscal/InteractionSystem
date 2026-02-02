using System.Collections.Generic;
using InteractionSystem.Scripts.Runtime.Core;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.Player
{
    public sealed class InteractionDetector : MonoBehaviour
    {
        [SerializeField] private Transform _interactorRoot;

        private readonly List<IInteractable> _candidates = new();
        public IInteractable Current { get; private set; }

        private void Reset()
        {
            _interactorRoot = transform.root;
        }

        private void Awake()
        {
            if (_interactorRoot == null)
            {
                _interactorRoot = transform.root;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // Auto pickup varsa anýnda topla (E gerektirmez)
            IAutoCollectable autoCollectable = other.GetComponentInParent<IAutoCollectable>();
            if (autoCollectable != null)
            {
                autoCollectable.Collect(_interactorRoot.gameObject);
                return;
            }

            IInteractable interactable = other.GetComponentInParent<IInteractable>();
            if (interactable == null)
                return;

            if (_candidates.Contains(interactable))
                return;

            _candidates.Add(interactable);
            RecalculateCurrent();
        }

        private void OnTriggerExit(Collider other)
        {
            IInteractable interactable = other.GetComponentInParent<IInteractable>();
            if (interactable == null)
                return;

            if (_candidates.Remove(interactable))
            {
                if (Current == interactable)
                {
                    Current = null;
                }

                RecalculateCurrent();
            }
        }

        private void Update()
        {
            // Destroy edilen objeler için temizlik
            for (int i = _candidates.Count - 1; i >= 0; i--)
            {
                if (_candidates[i] == null)
                {
                    _candidates.RemoveAt(i);
                }
            }

            RecalculateCurrent();
        }

        private void RecalculateCurrent()
        {
            if (_candidates.Count == 0)
            {
                Current = null;
                return;
            }

            Vector3 origin = _interactorRoot != null ? _interactorRoot.position : transform.position;

            IInteractable closest = null;
            float closestSqr = float.MaxValue;

            for (int i = 0; i < _candidates.Count; i++)
            {
                IInteractable candidate = _candidates[i];
                if (candidate == null)
                    continue;

                Component candidateComp = candidate as Component;
                if (candidateComp == null)
                    continue;

                float sqr = (candidateComp.transform.position - origin).sqrMagnitude;
                if (sqr < closestSqr)
                {
                    closestSqr = sqr;
                    closest = candidate;
                }
            }

            Current = closest;
        }
    }
}
