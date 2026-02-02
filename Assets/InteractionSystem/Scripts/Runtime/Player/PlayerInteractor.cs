using InteractionSystem.Scripts.Runtime.Core;
using InteractionSystem.Scripts.Runtime.UI;
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

        [Header("UI")]
        [SerializeField] private InteractionPromptUI _promptUI;
        [SerializeField] private InteractionProgressUI _progressUI;
        [SerializeField] private NotificationUI _notificationUI;

        private float _holdTimer;
        private IInteractable _lastTarget;
        private bool _holdCompleted;

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
            if (_interactAction == null || _detector == null)
                return;

            IInteractable target = _detector.Current;

            if (target != _lastTarget)
            {
                ResetHoldState();
                _lastTarget = target;
            }

            UpdateUI(target);

            if (target == null)
                return;

            // Hold interactable mý?
            IHoldInteractable hold = (target as Component)?.GetComponent<IHoldInteractable>();
            if (hold != null)
            {
                HandleHoldInteraction(target, hold);
                return;
            }

            // Normal "press" interaction
            if (_interactAction.action.WasPressedThisFrame())
            {
                target.Interact(gameObject);
            }
        }

        private void HandleHoldInteraction(IInteractable target, IHoldInteractable hold)
        {
            bool isPressed = _interactAction.action.IsPressed();

            if (!isPressed)
            {
                ResetHoldState();
                return;
            }

            if (_holdCompleted)
                return;

            _holdTimer += Time.deltaTime;

            float duration = Mathf.Max(0.05f, hold.HoldDurationSeconds);
            float progress01 = _holdTimer / duration;

            if (_progressUI != null)
            {
                _progressUI.Show();
                _progressUI.SetProgress01(progress01);
            }

            if (_holdTimer >= duration)
            {
                _holdCompleted = true;

                // interaction tamamlandý
                target.Interact(gameObject);

                if (_notificationUI != null)
                {
                    _notificationUI.Show("Chest opened!");
                }

                if (_progressUI != null)
                {
                    _progressUI.Hide();
                }
            }
        }

        private void ResetHoldState()
        {
            _holdTimer = 0f;
            _holdCompleted = false;

            if (_progressUI != null)
            {
                _progressUI.Hide();
            }
        }

        private void UpdateUI(IInteractable target)
        {
            if (_promptUI == null)
                return;

            if (target == null)
            {
                _promptUI.Hide();
                return;
            }

            string keyHint = GetInteractBindingDisplay();
            IHoldInteractable hold = (target as Component)?.GetComponent<IHoldInteractable>();

            if (hold != null)
            {
                string actionText = hold.GetHoldActionText();
                _promptUI.Show($"Hold {keyHint} to {actionText}");
                return;
            }

            _promptUI.Show($"Press {keyHint} to interact");
        }

        private string GetInteractBindingDisplay()
        {
            if (_interactAction == null)
                return "[?]";

            // Aktif control’ü yakalarsak en doðru yazýyý verir
            // (Keyboard E, Gamepad A gibi)
            string display = _interactAction.action.GetBindingDisplayString();

            if (string.IsNullOrWhiteSpace(display))
                return "[Interact]";

            return $"[{display}]";
        }
    }
}
