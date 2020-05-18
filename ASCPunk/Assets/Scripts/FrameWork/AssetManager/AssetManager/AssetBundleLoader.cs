using UnityEngine.Events;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace FrameWork.AssetManager
{
    //ab资源加载器
    public class AssetBundleLoader : IAssetLoader
    {
        private string assetRootPath; 
        private string mainfastPath;
        private static AssetBundleManifest manifest;

        public AssetBundleLoader(string assetPath,string mainfast) {
            assetRootPath = assetPath;
            mainfastPath = mainfast;
        }


        public T LoadAsset<T>(string path) where T : class {
            string absolutepath = path;

            path = PathUtils.NormalizePath(path);
           
            Debug.Log("[LoadAsset]: " + path);
            //打的ab包都资源名称和文件名都是小写的
            string assetBundleName = PathUtils.GetAssetBundleNameWithPath(path, assetRootPath);

            //加载Manifest文件
            LoadManifest();

            //获取文件依赖列表
            string[] dependencies = manifest.GetAllDependencies(assetBundleName);

            //加载依赖资源
            List<AssetBundle> assetbundleList = new List<AssetBundle>();
            foreach (string fileName in dependencies) {
                string dependencyPath = assetRootPath + "/" + fileName;
                Debug.Log("[AssetBundle]加载依赖资源: " + dependencyPath);
                assetbundleList.Add(AssetBundle.LoadFromFile(dependencyPath));
            }
            //4加载目标资源
            AssetBundle assetBundle = null;
            Debug.Log("[AssetBundle]加载目标资源: " + path);
            assetBundle = AssetBundle.LoadFromFile(path);
            assetbundleList.Insert(0, assetBundle);

            Object obj = assetBundle.LoadAsset(Path.GetFileNameWithoutExtension(path), typeof(T));

            //释放依赖资源
            UnloadAssetbundle(assetbundleList);

            //加入缓存
            AssetManager.Instance.pushCache(absolutepath, obj);

            return obj as T;
        }

        public IEnumerator LoadAssetAsync<T>(string path, UnityAction<T> callback) where T : class {
            string absolutepath = path;
            path = PathUtils.NormalizePath(path);


            Debug.Log("[LoadAssetAsync]: " + path);
            //打的ab包都资源名称和文件名都是小写的
            string assetBundleName = PathUtils.GetAssetBundleNameWithPath(path, assetRootPath);
            //加载Manifest文件
            LoadManifest();
            //获取文件依赖列表
            string[] dependencies = manifest.GetAllDependencies(assetBundleName);
            //加载依赖资源
            AssetBundleCreateRequest createRequest;
            List<AssetBundle> assetbundleList = new List<AssetBundle>();
            foreach (string fileName in dependencies) {
                string dependencyPath = assetRootPath + "/" + fileName;

                Debug.Log("[AssetBundle]加载依赖资源: " + dependencyPath);
                createRequest = AssetBundle.LoadFromFileAsync(dependencyPath);
                yield return createRequest;
                if (createRequest.isDone) {
                    assetbundleList.Add(createRequest.assetBundle);

                } else {
                    Debug.LogError("[AssetBundle]加载依赖资源出错");
                }

            }
            //加载目标资源
            AssetBundle assetBundle = null;
            Debug.Log("[AssetBundle]加载目标资源: " + path);
            createRequest = AssetBundle.LoadFromFileAsync(path);
            yield return createRequest;
            if (createRequest.isDone) {
                assetBundle = createRequest.assetBundle;
                //释放目标资源
                assetbundleList.Insert(0, assetBundle);
            }
            AssetBundleRequest abr = assetBundle.LoadAssetAsync(Path.GetFileNameWithoutExtension(path), typeof(T));
            yield return abr;
            Object obj = abr.asset;

            //加入缓存
            AssetManager.Instance.pushCache(absolutepath, obj);

            callback(obj as T);

            //释放依赖资源
            UnloadAssetbundle(assetbundleList);
        }


        // 加载 manifest 
        private void LoadManifest() {
            if (manifest == null) {
                string path = mainfastPath;
                Debug.Log("[AssetBundle]加载manifest:" + path);

                AssetBundle manifestAB = AssetBundle.LoadFromFile(path);
                manifest = manifestAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                manifestAB.Unload(false);
            }
        }
       
        private void UnloadAssetbundle(List<AssetBundle> list) {
            for (int i = 0; i < list.Count; i++) {
                list[i].Unload(false);
            }
            list.Clear();
        }
    }

}
