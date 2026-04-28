using System;
using UnityEngine;

[RequireComponent(typeof(BulletsPool))]
public class BulletsSpawner : MonoBehaviour
{
    [SerializeField] private float _offset;

    public event Action EnemyKilled;

    private BulletsPool _pool;

    private Vector3 _spawnPosition;

    private void Awake()
    {
        _pool = GetComponent<BulletsPool>();
    }

    public void Spawn(Transform parentTransform)
    {
        _spawnPosition = parentTransform.position + (parentTransform.right * _offset);

        Bullet bullet = _pool.GetObject();
        bullet.transform.position = _spawnPosition;
        bullet.transform.rotation = parentTransform.rotation;

        bullet.gameObject.SetActive(true);
        bullet.Died += ReturnBullet;
        bullet.EnemyKilled += InvokeEnemyKilled;
    }

    private void InvokeEnemyKilled()
    {
        EnemyKilled.Invoke();
    }

    private void ReturnBullet(Bullet bullet)
    {
        bullet.Died -= ReturnBullet;
        _pool.ReturnObject(bullet);
    }
}
