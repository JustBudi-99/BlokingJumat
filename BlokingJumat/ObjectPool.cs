using System;
using System.Collections.Generic;

public interface IPoolable
{
    void OnSpawnFromPool();
    void OnReturnToPool();
}

public class ObjectPool<T> where T : class
{
    private readonly Queue<T> pool = new Queue<T>();
    private readonly Func<T> createFunc;

    public ObjectPool(Func<T> createFunc, int prewarmCount)
    {
        this.createFunc = createFunc;
        for (int i = 0; i < prewarmCount; i++)
        {
            T obj = createFunc();
            pool.Enqueue(obj);
        }
    }

    public T Get()
    {
        T obj = pool.Count > 0 ? pool.Dequeue() : createFunc();
        (obj as IPoolable)?.OnSpawnFromPool();
        return obj;
    }

    public void Release(T obj)
    {
        (obj as IPoolable)?.OnReturnToPool();
        pool.Enqueue(obj);
    }
}