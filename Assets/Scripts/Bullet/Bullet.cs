using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action EnemyKilled;
    public event Action<Bullet> Died;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(DieAfterDelay());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            EnemyKilled?.Invoke();
        }
        if (collision.TryGetComponent(out Player player))
            player.Die();

        Died?.Invoke(this);
    }

    private IEnumerator DieAfterDelay()
    {
        float delay = 5;
        WaitForSeconds wait = new WaitForSeconds(delay);

        yield return wait;
        Died?.Invoke(this);
    }
}
