using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class CoroutineService
    {
        #region Internal Class

        private class CoroutineCore : MonoBehaviour { }

        #endregion

        #region Fields

        private static CoroutineService _instance;
        private readonly CoroutineCore _coroutineCore;

        #endregion

        #region Constructors

        private CoroutineService()
        {
            var coroutineService = new GameObject("CoroutineService");
            Object.DontDestroyOnLoad(coroutineService);

            _coroutineCore = coroutineService.AddComponent<CoroutineCore>();
        }

        #endregion

        #region Methods

        public Coroutine BeginCoroutine(IEnumerator coroutine)
        {
            return _coroutineCore.StartCoroutine(coroutine);
        }

        public void EndCoroutine(Coroutine coroutine)
        {
            _coroutineCore.StopCoroutine(coroutine);
        }

        #endregion

        #region Properties

        public static CoroutineService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CoroutineService();
                }

                return _instance;
            }
        }

        #endregion
    }
}
