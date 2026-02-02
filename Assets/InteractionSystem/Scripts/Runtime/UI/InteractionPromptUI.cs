using TMPro;
using UnityEngine;

namespace InteractionSystem.Scripts.Runtime.UI
{
    public sealed class InteractionPromptUI : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private TMP_Text _label;

        private void Awake()
        {
            if (_root != null)
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
        }

        public void Hide()
        {
            if (_root != null)
            {
                _root.SetActive(false);
            }
        }
    }
}
