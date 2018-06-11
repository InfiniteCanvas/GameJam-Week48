using UnityEngine;

namespace ScriptableObjectsFramework.FSM
{
    public abstract class FSM : MonoBehaviour
    {
        public State DefaultState;
        public State CurrentState { get; private set; }
        public State[] States;

        protected virtual void Awake()
        {
            CurrentState = DefaultState.Enter();
        }

        protected virtual void Update()
        {
            CurrentState.Update();
        }

        protected virtual void FixedUpdate()
        {
            CurrentState.FixedUpdate();
        }

        public virtual State TransitionTo(State state)
        {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState?.Enter();

            return CurrentState;
        }
    } 
}