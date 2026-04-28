using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    protected Queue<T> Pool = new Queue<T>();
    protected List<T> AllObjects = new List<T>();

    public abstract T GetObject();
    
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        Pool.Enqueue(obj);
    }

    public void Reset()
    {
        foreach (T obj in Pool)
            Destroy(obj.gameObject);

        foreach (T obj in AllObjects)
            Destroy(obj.gameObject);

        Pool.Clear();
        AllObjects.Clear();
    }

    protected T InstantiateObject(T prefab)
    {
        T obj = Instantiate(prefab);
        AllObjects.Add(obj);

        return obj;
    }
}
