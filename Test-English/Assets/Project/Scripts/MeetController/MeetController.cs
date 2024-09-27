using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.MeetController
{
    public class MeetController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;

        [SerializeField] private Image _fader;

        private void OnEnable()
        {
            gameObject.SetActive(true);
            
            _timerText.gameObject.SetActive(true);
            
            _timerText.DOFade(1, 0.01f);
            
            _fader.gameObject.SetActive(true);

            _fader.color = new Color(_fader.color.r, _fader.color.g, _fader.color.b, 197f / 256f);
            
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            for (var i = 3; i > 0; i--)
            {
                _timerText.text = $"{i}";
                
                yield return new WaitForSeconds(1f);
            }
            
            _timerText.DOFade(0, 0.2f).OnComplete(() =>
            {
                _timerText.gameObject.SetActive(false);
            });
            
            _fader.DOFade(0, 1f).OnComplete(() =>
            {
                gameObject.SetActive(false); 
            });
        }
    }
}