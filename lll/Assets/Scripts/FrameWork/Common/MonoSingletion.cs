using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace FrameWork
{
    public abstract class MonoSingletion<T> :  MonoBehaviour where T :new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }

        protected abstract void Init();

        protected MonoSingletion()
        {
            Init();
        }
    }
}
