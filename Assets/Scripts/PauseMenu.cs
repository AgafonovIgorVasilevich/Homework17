using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}