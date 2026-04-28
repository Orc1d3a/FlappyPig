using TMPro;
using UnityEngine;

public class ScoreUpdator : MonoBehaviour
{
    [SerializeField] private BulletsSpawner _bulletsSpawner;

    private TMP_Text _text;

    private int _startScore = 0;
    private int _currentScore = 0;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();

        SetScore(_startScore);
    }

    private void OnEnable()
    {
        _bulletsSpawner.EnemyKilled += AddScore;
    }

    private void OnDisable()
    {
        _bulletsSpawner.EnemyKilled -= AddScore;
    }

    public void Reset()
    {
        _currentScore = _startScore;

        SetScore(_startScore);
    }

    private void AddScore()
    {
        _currentScore++;

        SetScore(_currentScore);
    }

    private void SetScore(int score)
    {
        _text.text = score.ToString();
    }
}
