using System;
using UnityEngine;

[RequireComponent(typeof(InputDetector))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] BulletsSpawner _bulletsSpawner;

    public event Action Died;

    private InputDetector _inputDetector;
    private Rigidbody2D _rigidbody;

    private Vector3 _startPosition;

    private void Awake()
    {
        _inputDetector = GetComponent<InputDetector>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _inputDetector.ShotPressed += Shot;
    }

    private void OnDisable()
    {
        _inputDetector.ShotPressed -= Shot;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ceiling>(out _) == false)
            Die();
    }

    public void Die()
    {
        Died?.Invoke();
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;

        _rigidbody.velocity = Vector3.zero;
    }

    private void Shot()
    {
        _bulletsSpawner.Spawn(transform);
    }
}
