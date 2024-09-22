using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.PopUpController
{
    public class PopUpController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleText;

        [SerializeField] private Button _backButton;
        
        [SerializeField] private Button _retryButton;

        public void EnableWindow(bool isEnable) => gameObject.SetActive(isEnable);

        public void SetText(string text) => _titleText.text = text;
    }
}