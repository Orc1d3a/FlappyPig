using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    private BulletsSpawner _bulletsSpawner;

    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Die()
    {
        Died?.Invoke(this);
    }

    public void SetBulletsSpawner(BulletsSpawner bulletsSpawner)
    {
        _bulletsSpawner = bulletsSpawner;
    }

    private IEnumerator Shoot()
    {
        float delay = 2;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (gameObject.activeSelf)
        {
            yield return wait;

            _bulletsSpawner.Spawn(transform);
        }
    }
}
