using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.PopUpController
{
    public class PopUpController : MonoBehaviour
    {
        public event Action OnRetry;
        
        public event Action OnBack;
        
        [SerializeField] private TMP_Text _titleText;

        [SerializeField] private Button _backButton;
        
        [SerializeField] private Button _retryButton;

        private void Awake()
        {
            _backButton.onClick.AddListener(OnClickBackButtonHandler);
            _retryButton.onClick.AddListener(OnClickRetryHandler);
        }

        public void EnableWindow(bool isEnable) => gameObject.SetActive(isEnable);

        public void SetText(string text) => _titleText.text = text;

        private void OnClickBackButtonHandler() => OnBack?.Invoke();

        private void OnClickRetryHandler() => OnRetry?.Invoke();
    }
}