using System;
using UnityEngine;

namespace Project.Scripts.AttemptController
{
    public class AttemptController : MonoBehaviour
    {
        public int CountAttempt => _countAttempt;
        
        private int _countAttempt = 3;

        public void ResetAttempt() => _countAttempt = 3;

        public void RetractionAttempt() => _countAttempt--;
    }
}