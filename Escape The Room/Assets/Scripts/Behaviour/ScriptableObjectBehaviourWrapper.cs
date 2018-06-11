using UnityEngine;

namespace ScriptableObjectsFramework.Behaviour
{
    public class ScriptableObjectBehaviourWrapper : MonoBehaviour
    {
        public ScriptableObjectBehaviour Behaviour;

        public bool OnUpdate, OnFixedUpdate, OnLateUpdate;
        private bool _subscribed;

        protected virtual void Awake()
        {
            Behaviour.Init(this);
            Behaviour.Awake();

            Subscribe();
        }

        protected virtual void Start()
        {
            Behaviour.Start();
        }

        #region Hooking up unity calls
        private void Subscribe()
        {
            if (OnUpdate)
                ScriptableObjectBehaviourWrapperHelper.GetOrCreateInstance().OnUpdate += ScriptableObjectBehaviourWrapper_OnUpdate;
            if (OnFixedUpdate)
                ScriptableObjectBehaviourWrapperHelper.GetOrCreateInstance().OnFixedUpdate += ScriptableObjectBehaviourWrapper_OnFixedUpdate;
            if (OnLateUpdate)
                ScriptableObjectBehaviourWrapperHelper.GetOrCreateInstance().OnLateUpdate += ScriptableObjectBehaviourWrapper_OnLateUpdate;
            _subscribed = true;
        }

        private void Unsubscribe()
        {
            //if helper is dead, there are no subscriptions anyways
            _subscribed = false;
            if (!ScriptableObjectBehaviourWrapperHelper.IsAlive) return;

            if (OnUpdate)
                ScriptableObjectBehaviourWrapperHelper.GetOrCreateInstance().OnUpdate -= ScriptableObjectBehaviourWrapper_OnUpdate;
            if (OnFixedUpdate)
                ScriptableObjectBehaviourWrapperHelper.GetOrCreateInstance().OnFixedUpdate -= ScriptableObjectBehaviourWrapper_OnFixedUpdate;
            if (OnLateUpdate)
                ScriptableObjectBehaviourWrapperHelper.GetOrCreateInstance().OnLateUpdate -= ScriptableObjectBehaviourWrapper_OnLateUpdate;
        }

        private void ScriptableObjectBehaviourWrapper_OnLateUpdate()
        {
            Behaviour.LateUpdate();
        }

        private void ScriptableObjectBehaviourWrapper_OnFixedUpdate()
        {
            Behaviour.FixedUpdate();
        }

        private void ScriptableObjectBehaviourWrapper_OnUpdate()
        {
            Behaviour.Update();
        }

        private void OnDisable()
        {
            if (_subscribed)
                Unsubscribe();
        }

        private void OnEnable()
        {
            if (!_subscribed)
                Subscribe();
        }
        #endregion
    }
}