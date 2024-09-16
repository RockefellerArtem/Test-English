using System.Collections.Generic;
using Project.Scripts.SO.Enum;
using UnityEngine;

namespace Project.Scripts.SO
{
    [CreateAssetMenu(menuName = "Book/Language")]
    public class LanguageBook : ScriptableObject
    {
        public LanguageType Language => _language;
        
        public List<Block> Blocks => _blocks;
        
        [SerializeField] private LanguageType _language;

        [SerializeField] private List<Block> _blocks;
    }
}