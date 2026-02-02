using TMPro;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.UI
{
    public sealed class NotificationUI : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private float _duration = 2f;

        private float _timer;

        private void Awake()
        {
            if (_root != null)
            {
                _root.SetActive(false);
            }
        }

        private void Update()
        {
            if (_timer <= 0f)
                return;

            _timer -= Time.deltaTime;
            if (_timer <= 0f && _root != null)
            {
                _root.SetActive(false);
            }
        }

        public void Show(string message)
        {
            if (_label != null)
            {
                _label.text = message;
            }

            if (_root != null)
            {
                _root.SetActive(true);
            }

            _timer = _duration;
        }
    }
}
