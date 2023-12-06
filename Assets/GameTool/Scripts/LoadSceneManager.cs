using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameTool
{
    public class LoadSceneManager : SingletonMonoBehaviour<LoadSceneManager>
    {
        public const string nameSceneSpl = "SPL";
        public const string nameSceneHome = "HomeScene";
        public const string nameSceneGame = "GameScene";

        protected override void Awake()
        {
            base.Awake();
            this.PostEvent(eEventType.SceneLoaded);
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadAsyncScene(sceneName));
        }

        public void LoadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        // public void LoadNextBuildScene()
        // {
        //     StartCoroutine(LoadAsyncScene(SceneManager.GetActiveScene().buildIndex + 1));
        // }
        //
        // public void LoadPreviousBuildScene()
        // {
        //     StartCoroutine(LoadAsyncScene(SceneManager.GetActiveScene().buildIndex - 1));
        // }
        
        public void LoadSceneSpl()
        {
            StartCoroutine(LoadAsyncScene(nameSceneSpl));
        }

        public void LoadSceneHome()
        {
            StartCoroutine(LoadAsyncScene(nameSceneHome));
        }

        public void LoadSceneGame()
        {
            StartCoroutine(LoadAsyncScene(nameSceneGame));
        }

        protected IEnumerator LoadAsyncScene(string nameScene)
        {
            yield return TransistionFX.Instance.OnLoadScene();
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameScene);
            this.PostEvent(eEventType.SceneLoaded);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            TransistionFX.Instance.EndLoadScene();
        }
        
        // protected IEnumerator LoadAsyncScene(int sceneBuildIndex)
        // {
        //     yield return TransistionFX.Instance.OnLoadScene();
        //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndex);
        //     this.PostEvent(eEventType.SceneLoaded);
        //     while (!asyncLoad.isDone)
        //     {
        //         yield return null;
        //     }
        //     TransistionFX.Instance.EndLoadScene();
        // }
    }
}