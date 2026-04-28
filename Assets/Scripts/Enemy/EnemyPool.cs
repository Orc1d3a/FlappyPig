using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField] private Enemy[] _prefab;

    public override Enemy GetObject()
    {
        if (Pool.Count == 0)
            return InstantiateObject(_prefab[Random.Range(0, _prefab.Length - 1)]);

        return Pool.Dequeue();
    }
}