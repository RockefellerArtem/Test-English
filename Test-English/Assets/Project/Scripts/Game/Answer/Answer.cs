using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Game.Answer
{
    public class Answer : MonoBehaviour
    {
        public event Action<Answer> OnAnswer;
        
        public event Action<Answer> OnAfterAnswer;
        
        public bool IsCorrect {get; private set;}
        
        [SerializeField] private Button _button;
        
        [SerializeField] private TMP_Text _text;

        [SerializeField] private Image _outline;
        
        private void OnEnable() => _button.onClick.AddListener(OnClickAnswerHandler);

        private void OnDisable() => _button.onClick.RemoveListener(OnClickAnswerHandler);

        public void SetWord(string word) => _text.text = word;
        
        public void SetIsCorrect(bool isCorrect) => IsCorrect = isCorrect;

        public void ResetOutline() => _outline.gameObject.SetActive(false);
        
        public void CorrectAnswer()
        {
            _outline.gameObject.SetActive(true);
            _outline.DOColor(Color.green, 1f).OnComplete(() =>
            {
                OnAfterAnswer?.Invoke(this);
                _outline.gameObject.SetActive(false);
            });
        }

        public void NotCorrectAnswer()
        {
            _outline.gameObject.SetActive(true);
            _outline.DOColor(Color.red, 1f).OnComplete(() =>
            {
                OnAfterAnswer?.Invoke(this);
                _outline.gameObject.SetActive(false);
            });
        }
        
        private void OnClickAnswerHandler() => OnAnswer?.Invoke(this);
    }
}