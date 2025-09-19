using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Spawners
{
    public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T Prefab;
        [SerializeField] private int _poolCapacity;
        [SerializeField] private int _poolMaxSize;

        protected ObjectPool<T> ObjectPool;
        protected List<T> ActiveObjects = new List<T>();

        protected int CreatedObjectCount = 0;

        private void Awake()
        {
            ObjectPool = new ObjectPool<T>
                (
                createFunc: () => CreateFunc(),
                actionOnGet: (@object) => ChangeParameters(@object),
                actionOnRelease: (@object) => @object.gameObject.SetActive(false),
                actionOnDestroy: (@object) => DestroyObject(@object),
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize
                );
        }

        public abstract T CreateFunc();

        public virtual void DestroyObject(T @object)
        {
            Destroy(@object.gameObject);
        }

        public virtual void ReleaseObjectToPool(T @object)
        {
            ObjectPool.Release(@object);
            ActiveObjects.Remove(@object);
        }

        public virtual void ChangeParameters(T @object)
        {
            @object.gameObject.SetActive(true);
            ActiveObjects.Add(@object);
        }

        public void SpawnObject()
        {
            ObjectPool.Get();
        }

        public void ReleaseAllObjectsToPool()
        {
            foreach (var obj in ActiveObjects)
            {
                ObjectPool.Release(obj);
            }

            ActiveObjects.Clear();
        }
    }
}
