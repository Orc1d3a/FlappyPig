using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyPool))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private BulletsSpawner _bulletsSpawner;
    [SerializeField] private Transform _maxPosition;
    [SerializeField] private Transform _minPosition;

    private EnemyPool _pool;

    private bool _shouldSpawn = true;

    private void Awake()
    {
        _pool = GetComponent<EnemyPool>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float delay = 3;
        WaitForSeconds wait = new WaitForSeconds(delay);

        Enemy enemy;
        Vector3 spawnPosition;

        while (_shouldSpawn)
        {
            spawnPosition = transform.position;
            spawnPosition.y = Random.Range(_minPosition.position.y, _maxPosition.position.y);

            enemy = _pool.GetObject();

            enemy.SetBulletsSpawner(_bulletsSpawner);
            enemy.transform.position = spawnPosition;
            enemy.gameObject.SetActive(true);

            enemy.Died += ReturnEnemy;

            yield return wait;
        }
    }

    private void ReturnEnemy(Enemy enemy)
    {
        enemy.Died -= ReturnEnemy;
        _pool.ReturnObject(enemy);
    }
}
