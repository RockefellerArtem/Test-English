using System;
using System.Collections.Generic;
using Project.Scripts.SO;
using TMPro;
using UnityEngine;
using Answer = Project.Scripts.Game.Answer.Answer;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text _word;
    
    [SerializeField] private List<Answer> _answers;
    
    [SerializeField] private LanguageBook _languageBook;

    private int _currentBlock = 0;

    private void Start()
    {
        SetFirstValue();   
        SetWord();
    }

    private void OnEnable()
    {
        for (int i = 0; i < _answers.Count; i++)
        {
            _answers[i].OnAnswer += OnClickAnswerHandler;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _answers.Count; i++)
        {
            _answers[i].OnAnswer -= OnClickAnswerHandler;
        }
    }

    private void SetFirstValue() => SetAnswersButtons();

    private void SetWord() => _word.text = GetCurrentBlock().Word;
    
    private void SwitchBlock()
    {
        
    }
    
    private void OnClickAnswerHandler(Answer answer)
    {
        if (answer.IsCorrect)
        {
            // если верно то зеленая обводка и след шаг
            answer.CorrectAnswer();
        }
        else
        {
            // если неверено то красная обводка и след шаг и минус 1 попытка
            answer.NotCorrectAnswer();
        }
        
        // после нажатия отправлять в контроллер попыток (там тоже сделать калбек на конец попыток)
        
        SwitchBlock();
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
                _answers[i].SetWord(block.Answers[j].AnswerText);
                _answers[i].SetIsCorrect(block.Answers[j].IsCorrect);
            }
        }
    }
}
