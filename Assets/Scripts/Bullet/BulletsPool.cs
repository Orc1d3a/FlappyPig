using UnityEngine;

public class BulletsPool : ObjectPool<Bullet>
{
    [SerializeField] private Bullet _prefab;

    public override Bullet GetObject()
    {
        if(Pool.Count == 0)
            return InstantiateObject(_prefab);

        return Pool.Dequeue();
    }
}
