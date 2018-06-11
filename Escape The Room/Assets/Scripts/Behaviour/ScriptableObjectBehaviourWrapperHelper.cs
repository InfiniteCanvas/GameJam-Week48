using System;
using UnityEngine;

namespace ScriptableObjectsFramework.Behaviour
{
    public class ScriptableObjectBehaviourWrapperHelper : MonoBehaviour
    {
        public static bool IsAlive => _instance != null;

        public event Action OnUpdate;
        public event Action OnFixedUpdate;
        public event Action OnLateUpdate;

        private static ScriptableObjectBehaviourWrapperHelper _instance;
        public static ScriptableObjectBehaviourWrapperHelper GetOrCreateInstance()
        {
            if (_instance == null)
            {
                _instance = new GameObject(nameof(ScriptableObjectBehaviourWrapperHelper))
                    .AddComponent<ScriptableObjectBehaviourWrapperHelper>();
            }

            return _instance;
        }

        private void Update()
        {

            OnUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }
    }

}