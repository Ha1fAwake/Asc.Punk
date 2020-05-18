using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace GameSystem.FightSystem.CommonInterface
{
    public class ObjectName
    {

    }
    public class ObjectPool<T> where T : new()
    {
        private Dictionary<string, Queue<T>> pool;
        private Dictionary<string, Func<string, T>> loaderDic;
        private int capacity = 10;
        public int Capacity { get => capacity; set => capacity = value; }

        public ObjectPool()
        {
            pool = new Dictionary<string, Queue<T>>();
            loaderDic = new Dictionary<string, Func<string, T>>();
        }

        public void ClearPool()
        {
            pool.Clear();
        }

        public void AddLoader(Func<string, T> func, string type)
        {
            loaderDic.Add(type, func);
        }

        public virtual void ReturnObj(T obj, string type)
        {
            Queue<T> queue;
            if (pool.TryGetValue(type, out queue))
            {
                queue.Enqueue(obj);
            }
            else
            {
                Debug.LogError("this obj is not get from objPool, pool can not recovery it");
                throw new Exception("this obj is not get from objPool, pool can not recovery it");
            }
        }

        public virtual T GetObj(string type, string path = null)
        {
            Queue<T> queue;
            if (pool.TryGetValue(type, out queue))
            {
                if (queue.Count > 0)
                {
                    return queue.Dequeue();
                }
                Debug.LogError(type + "'s pool is empty.");
                return default(T);
            }
            else
            {
                queue = LoadObj(type, path);
                return queue.Dequeue();
            }
        }

        public virtual Queue<T> LoadObj(string type, string path = null, int size = 10)
        {
            Queue<T> queue = null;
            Func<string, T> func = null;
            if (loaderDic.TryGetValue(type, out func))
            {

            }
            if (pool.TryGetValue(type, out queue))
            {
                if (queue.Count < size)
                {
                    int resize = size - queue.Count;
                    LoadObj(queue, func, path, resize);
                }
            }
            else
            {
                queue = new Queue<T>();
                LoadObj(queue, func, path, size);
            }
            return queue;
        }

        public virtual Queue<T> LoadObj(Queue<T> queue, Func<string, T> func, string path = null, int size = 10)
        {
            if (func != null)
            {
                for (int i = 0; i < size; i++)
                {
                    queue.Enqueue(func(path));
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    queue.Enqueue(new T());
                }
            }
            return queue;
        }
    }
}
