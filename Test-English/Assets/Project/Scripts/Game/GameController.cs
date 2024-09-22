using System.Collections.Generic;
using Project.Scripts.AttemptController;
using Project.Scripts.PopUpController;
using Project.Scripts.SO;
using TMPro;
using UnityEngine;
using Answer = Project.Scripts.Game.Answer.Answer;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text _word;
    
    [SerializeField] private List<Answer> _answers;
    
    [SerializeField] private LanguageBook _languageBook;
    
    [Space]

    [SerializeField] private PopUpController _popUpController;

    [Space] [SerializeField] private TMP_Text _attemptText;

    private AttemptController _attemptController = new();

    private int _currentBlock = 0;

    private int _correctAnswers = 0;

    private void Start()
    {
        SetFirstValue();   
        SetWord();
        
        _attemptController.ResetAttempt();
        
        _attemptText.text = $"Осталось попыток: {_attemptController.CountAttempt}";

        _correctAnswers = 0;
    }

    private void OnEnable()
    {
        for (int i = 0; i < _answers.Count; i++)
        {
            _answers[i].OnAnswer += OnClickAnswerHandler;
            _answers[i].OnAfterAnswer += OnAfterAnswerHandler;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _answers.Count; i++)
        {
            _answers[i].OnAnswer -= OnClickAnswerHandler;
            _answers[i].OnAfterAnswer -= OnAfterAnswerHandler;
        }
    }

    private void SetFirstValue() => SetAnswersButtons();

    private void SetWord() => _word.text = GetCurrentBlock().Word;
    
    private void SwitchBlock()
    {
        _currentBlock++;
        
        SetAnswersButtons();
        
        SetWord();
    }
    
    private void OnClickAnswerHandler(Answer answer)
    {
        if (answer.IsCorrect)
        {
            answer.CorrectAnswer();

            _correctAnswers++;
        }
        else
        {
            answer.NotCorrectAnswer();

            _attemptController.RetractionAttempt();
            
            if (_attemptController.CountAttempt == 0)
            {
                _popUpController.EnableWindow(true);
                
                _popUpController.SetText($"Игры завершена\n{ResultGame()}");
            }
            
            _attemptText.text = $"Осталось попыток: {_attemptController.CountAttempt}";
        }
    }

    private Block GetCurrentBlock()
    {
        return _languageBook.Blocks[_currentBlock];
    }

    private void SetAnswersButtons()
    {
        var block = GetCurrentBlock();

        for (var i = 0; i < block.Answers.Count; i++)
        {
            for (var j = 0; j < _answers.Count; j++)
            {                                                           
                _answers[i].SetWord(block.Answers[i].AnswerText);
                _answers[i].SetIsCorrect(block.Answers[i].IsCorrect);
            }
        }
    }
    
    private void OnAfterAnswerHandler(Answer answer)
    {
        answer.ResetOutline();
        
        SwitchBlock();
    }

    private string ResultGame()
    {
        var result = _correctAnswers switch
        {
            < 3 => "Ужасно",
            > 9 => "Отлично!",
            > 6 => "Средне",
            _ => ""
        };

        return result;
    }
}