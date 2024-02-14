using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private Player _player;

    private void Start() => Time.timeScale = 1.0f;

    private void OnEnable() => _player.Died += ShowFinalScreen;

    private void OnDisable() => _player.Died -= ShowFinalScreen;

    public void GameRestart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void ShowFinalScreen()
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}