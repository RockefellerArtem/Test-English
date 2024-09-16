using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Answer
{
    public class Answer : MonoBehaviour
    {
        public event Action<Answer> OnAnswer;
        
        public bool IsCorrect {get; private set;}
        
        [SerializeField] private Button _button;
        
        [SerializeField] private TMP_Text _text;

        [SerializeField] private Image _outline;
        
        private void OnEnable() => _button.onClick.AddListener(OnClickAnswerHandler);

        private void OnDisable() => _button.onClick.RemoveListener(OnClickAnswerHandler);

        public void SetWord(string word) => _text.text = word;
        
        public void SetIsCorrect(bool isCorrect) => IsCorrect = isCorrect;

        public void CorrectAnswer()
        {
            _outline.gameObject.SetActive(true);
            _outline.color = Color.green;
        }

        public void NotCorrectAnswer()
        {
            _outline.color = Color.red;
        }
        
        private void OnClickAnswerHandler()
        {
            OnAnswer?.Invoke(this);
        }
    }
}