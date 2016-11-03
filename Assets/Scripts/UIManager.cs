using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
    [SerializeField]
    private GameObject _playingUIPanel;
    [SerializeField]
    private GameObject _gameOverUIPanel;
    [SerializeField]
    private GameObject _mainMenuUIPanel;
    private GameObject _currentUIPanel;

    public void ShowMainMenu()
    {
        _mainMenuUIPanel.SetActive(true);
        _currentUIPanel = _mainMenuUIPanel;
    }

    public void ShowPlayingPanel()
    {
        _mainMenuUIPanel.SetActive(false);
        _currentUIPanel = _playingUIPanel;
        _currentUIPanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        _currentUIPanel.SetActive(false);
        _currentUIPanel = _gameOverUIPanel;
        _currentUIPanel.SetActive(true);
    }
}
