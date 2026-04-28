using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private Canvas _startWindow;
    [SerializeField] private Canvas _playWindow;
    [SerializeField] private Canvas _loseWindow;
    [SerializeField] private Player _player;

    [HideInInspector] public bool IsPlay;

    private void Awake()
    {
        Time.timeScale = 0f;

        _startWindow.gameObject.SetActive(true);
        _playWindow.gameObject.SetActive(false);
        _loseWindow.gameObject.SetActive(false);

        IsPlay = false;
    }

    private void OnEnable()
    {
        _player.Died += Lose;
    }

    private void OnDisable()
    {
        _player.Died -= Lose;
    }

    public void Lose()
    {
        _playWindow.gameObject.SetActive(false);
        _loseWindow.gameObject.SetActive(true);

        IsPlay = false;

        Time.timeScale = 0f;
    }

    public void Play()
    {
        _startWindow.gameObject.SetActive(false);
        _playWindow.gameObject.SetActive(true);
        _loseWindow.gameObject.SetActive(false);

        IsPlay = true;

        Time.timeScale = 1f;
    }
}
