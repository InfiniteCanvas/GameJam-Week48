using UnityEngine;

namespace ScriptableObjectsFramework.FSM
{
    public abstract class State : ScriptableObject
    {
        public string Name => this.GetType().Name;

        public abstract State Enter();
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract State Exit();
    }
}