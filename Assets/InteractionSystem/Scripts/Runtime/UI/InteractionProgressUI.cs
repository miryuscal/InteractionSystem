using UnityEngine;
using UnityEngine.UI;

namespace InteractionSystem.Scripts.Runtime.UI
{
    public sealed class InteractionProgressUI : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private Image _fillImage;

        private void Awake()
        {
            if (_root != null)
            {
                _root.SetActive(false);
            }

            SetProgress01(0f);
        }

        public void Show()
        {
            if (_root != null)
            {
                _root.SetActive(true);
            }
        }

        public void Hide()
        {
            if (_root != null)
            {
                _root.SetActive(false);
            }

            SetProgress01(0f);
        }

        public void SetProgress01(float value01)
        {
            if (_fillImage == null)
                return;

            _fillImage.fillAmount = Mathf.Clamp01(value01);
        }
    }
}
