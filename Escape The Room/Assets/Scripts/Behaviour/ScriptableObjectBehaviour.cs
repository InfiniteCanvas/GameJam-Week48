using UnityEngine;

namespace ScriptableObjectsFramework.Behaviour
{
    public abstract class ScriptableObjectBehaviour : ScriptableObject
    {
        protected ScriptableObjectBehaviourWrapper Wrapper;

        public void Init(ScriptableObjectBehaviourWrapper wrapper)
        {
            Wrapper = wrapper;
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
    } 
}