using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace FrameWork.ResourceLoader
{
    public class ResourceManager : MonoSingletion<ResourceManager>
    {
        protected override void Init()
        {
            throw new NotImplementedException();
        }

        public GameObject LoadGameObj(string path)
        {
            return null;
        }

        public void AnsycLoadGameObj(string path, Action<GameObject> action)
        {

        }

    }
}
