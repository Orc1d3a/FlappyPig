using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BulletsPool _bulletsPool;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private WindowsManager _windowsManager;
    [SerializeField] private ScoreUpdator _scoreUpdator;

    public void Restart()
    {
        _player.Reset();
        _bulletsPool.Reset();
        _enemyPool.Reset();
        _scoreUpdator.Reset();

        _windowsManager.Play();
    }
}
