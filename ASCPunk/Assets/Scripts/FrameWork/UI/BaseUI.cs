using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameWork
{
    public abstract class BaseUI : MonoBehaviour
    {
        private Transform _CachedTransform;
        /// <summary>
        /// Gets the cached transform.
        /// </summary>
        /// <value>The cached transform.</value>
        public Transform cachedTransform
        {
            get
            {
                if (!_CachedTransform)
                {
                    _CachedTransform = this.transform;
                }
                return _CachedTransform;
            }
        }

        private GameObject _CachedGameObject;
        /// <summary>
        /// Gets the cached game object.
        /// </summary>
        /// <value>The cached game object.</value>
        public GameObject cachedGameObject
        {
            get
            {
                if (!_CachedGameObject)
                {
                    _CachedGameObject = this.gameObject;
                }
                return _CachedGameObject;
            }
        }

        /// <summary>
        /// Gets the type of the user interface.
        /// </summary>
        /// <returns>The user interface type.</returns>
        public abstract UIType GetUIType();

        /// <summary>
        /// UI层级置顶
        /// </summary>
        protected virtual void SetDepthToTop()
        {

        }


        // Use this for initialization
        void Start()
        {
            OnStart();
        }

        void Awake()
        {
            OnAwake();
        }

        // Update is called once per frame
        void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        /// <summary>
        /// Release this instance.
        /// </summary>
        public void Release()
        {
            GameObject.Destroy(cachedGameObject);
            OnRelease();
        }

        protected virtual void OnStart()
        {

        }

        protected virtual void OnAwake()
        {
            this.OnPlayOpenUIAudio();
        }

        protected virtual void OnUpdate(float deltaTime)
        {

        }

        protected virtual void OnRelease()
        {
            this.OnPlayCloseUIAudio();
        }


        /// <summary>
        /// 播放打开界面音乐
        /// </summary>
        protected virtual void OnPlayOpenUIAudio()
        {

        }

        /// <summary>
        /// 播放关闭界面音乐
        /// </summary>
        protected virtual void OnPlayCloseUIAudio()
        {

        }

        public virtual void SetUIparam(params object[] uiParams)
        {

        }


        protected virtual IEnumerator<int> OnLoadData()
        {
            yield break;
        }

        public void SetUIWhenOpening(params object[] uiParams)
        {
            StartCoroutine(OnLoadData());
        }
    }
}