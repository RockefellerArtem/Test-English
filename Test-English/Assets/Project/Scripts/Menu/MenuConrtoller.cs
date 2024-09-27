using UnityEngine;
using UnityEngine.UI;

public class MenuConrtoller : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    [SerializeField] private GameController _gameController;

    private void OnEnable() => _playButton.onClick.AddListener(OnClickPlayHandler);

    private void OnClickPlayHandler()
    {
        gameObject.SetActive(false);
        
        _gameController.gameObject.SetActive(true);
    }
}
